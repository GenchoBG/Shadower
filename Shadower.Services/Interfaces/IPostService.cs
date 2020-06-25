using System.Collections.Generic;
using System.Linq;
using Shadower.Data.Models;

namespace Shadower.Services.Interfaces
{
    public interface IPostService
    {
        Post AddPost(string link, IEnumerable<IList<double>> embeddings);

        bool AddTrackedFace(IList<double> embedding);

        void ArchivePost(int id);

        IEnumerable<Post> FindPostsByEmbedding(IList<double> embedding);

        IQueryable<Post> GetImportant();
    }
}
