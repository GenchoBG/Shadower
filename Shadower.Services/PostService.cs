using System.Collections.Generic;

namespace Shadower.Services
{
    public class PostService : IPostService
    {
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
