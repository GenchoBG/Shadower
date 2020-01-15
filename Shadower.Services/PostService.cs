using System.Collections.Generic;
using Shadower.Data;

namespace Shadower.Services
{
    public class PostService : IPostService
    {
        private readonly ShadowerDbContext db;

        public PostService(ShadowerDbContext db)
        {
            this.db = db;
        }

        public void AddPost(string link, IEnumerable<IEnumerable<float>> embeddings)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> FindPostsByEmbedding(IEnumerable<float> embedding)
        {
            throw new System.NotImplementedException();
        }
    }
}
