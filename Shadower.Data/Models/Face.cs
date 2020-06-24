using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shadower.Data.Models
{
    public class Face
    {
        [Key]
        public int Id { get; set; }

        public bool Tracked { get; set; }

        public ICollection<PostFace> Posts { get; set; }

        public ICollection<Embedding> Embeddings { get; set; }
    }
}
