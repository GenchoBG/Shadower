using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shadower.Data.Models
{
    public class PostFace
    {
        public int FaceId { get; set; }

        [Required]
        public Face Face { get; set; }

        public int PostId { get; set; }

        [Required]
        public Post Post { get; set; }
    }
}
