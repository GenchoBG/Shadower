using System.Collections.Generic;

namespace Shadower.Web.Models
{
    public class PostAddModel
    {
        public string Link { get; set; }

        public IList<IList<double>> Embeddings { get; set; }
    }
}
