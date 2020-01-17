using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shadower.Data.Models
{
    public class Embedding
    {
        [Key]
        public int Id { get; set; }

        public int FaceId { get; set; }

        [Required]
        public Face Face { get; set; }

        public ICollection<EmbeddingValue> Values { get; set; } = new HashSet<EmbeddingValue>();
    }
}
