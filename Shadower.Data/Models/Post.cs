using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shadower.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }

        public ICollection<PostFace> Faces { get; set; }
    }
}
