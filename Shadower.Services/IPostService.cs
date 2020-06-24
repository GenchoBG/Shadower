using System.Collections.Generic;
using Shadower.Data.Models;

namespace Shadower.Services
{
    public interface IPostService
    {
        void AddPost(string link, IEnumerable<IList<double>> embeddings);

        bool AddTrackedFace(IList<double> embedding);

        IEnumerable<Post> FindPostsByEmbedding(IList<double> embedding);
    }
}
