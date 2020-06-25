using System.Collections.Generic;
using System.Linq;
using Shadower.Data.Models;

namespace Shadower.Services
{
    public interface IPostService
    {
        bool AddPost(string link, IEnumerable<IList<double>> embeddings);

        bool AddTrackedFace(IList<double> embedding);

        IEnumerable<Post> FindPostsByEmbedding(IList<double> embedding);

        IQueryable<Post> GetImportant();
    }
}
