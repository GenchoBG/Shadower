using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shadower.Data;
using Shadower.Data.Models;

namespace Shadower.Services
{ 
    public class PostService : IPostService
    {
        private readonly ShadowerDbContext db;
        private const double SimilarityThreshhold = 13;

        public PostService(ShadowerDbContext db)
        {
            this.db = db;
        }

        public void AddPost(string link, IEnumerable<IList<double>> embeddings)
        {
            var newEmbeddings = new List<Embedding>();

            foreach (var embedding in embeddings)
            {
                var newEmbedding = new Embedding();

                for (int i = 0; i < embedding.Count; i++)
                {
                    newEmbedding.Values.Add(new EmbeddingValue()
                    {
                        Index = i,
                        Value = embedding[i]
                    });
                }

                var (mostSimilar, distance) = this.FindMostSimilarEmbedding(embedding);

                if (distance <= SimilarityThreshhold)
                {
                    newEmbedding.FaceId = mostSimilar.FaceId;
                }
                else
                {
                    newEmbedding.Face = new Face();
                }

                newEmbeddings.Add(newEmbedding);
            }

            this.db.Embeddings.AddRange(newEmbeddings);
            this.db.SaveChanges();

            var post = new Post()
            {
                Link = link,
                Faces = newEmbeddings
                .Select(e => e.FaceId)
                .Distinct()
                .Select(fid => new PostFace()
                {
                    FaceId = fid
                }).ToList()
            };

            this.db.Posts.Add(post);
            this.db.SaveChanges();
        }

        public IEnumerable<Post> FindPostsByEmbedding(IList<double> embedding)
        {
            var (mostSimilar, distance) = this.FindMostSimilarEmbedding(embedding);

            if (distance <= SimilarityThreshhold)
            {
                var posts = this.db.Posts.Where(p => p.Faces.Any(pf => pf.FaceId == mostSimilar.FaceId)).ToList();

                return posts;
            }

            return new List<Post>();
        }

        private (Embedding, double) FindMostSimilarEmbedding(IList<double> embedding)
        {
            if (!this.db.Embeddings.Any())
            {
                return (null, double.MaxValue);
            }

            var mostSimilar = this.db.Embeddings.Include(e => e.Values).ToList().OrderBy(e =>
                    this.EucledianDistance(embedding, e))
                .First();

            return (mostSimilar, this.EucledianDistance(embedding, mostSimilar));
        }

        private double EucledianDistance(IList<double> embedding1, Embedding embedding2)
        {
            var values = embedding2.Values.OrderBy(v => v.Index).Select(v => v.Value).ToList();

            return this.EucledianDistance(embedding1, values);
        }

        private double EucledianDistance(IList<double> embedding1, IList<double> embedding2)
        {
            var sum = 0D;
            for (int i = 0; i < embedding1.Count; i++)
            {
                sum += Math.Pow(embedding1[i] - embedding2[i], 2);
            }

            return Math.Sqrt(sum);
        }
    }
}
