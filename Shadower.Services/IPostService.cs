using System.Collections.Generic;

namespace Shadower.Services
{
    public interface IPostService
    {
        void AddPost(string link, IEnumerable<IEnumerable<float>> embeddings);

        IEnumerable<string> FindPostsByEmbedding(IEnumerable<float> embedding);
    }
}
