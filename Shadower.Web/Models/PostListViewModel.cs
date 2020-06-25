using System;

namespace Shadower.Web.Models
{
    public class PostListViewModel
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public DateTime UploadedDateTime { get; set; }

        public bool Archived { get; set; }
    }
}
