using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shadower.Data.Models
{
    public class Face
    {
        [Key]
        public int Id { get; set; }

        public ICollection<PostFace> Posts { get; set; }

        public ICollection<Embedding> Embeddings { get; set; }
    }
}
