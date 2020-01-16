using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shadower.Data.Models
{
    public class EmbeddingValue
    {
        [Key]
        public int Id { get; set; }

        public int EmbeddingId { get; set; }

        public int Index { get; set; }

        public double Value { get; set; }
    }
}
