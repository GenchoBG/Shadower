using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shadower.Services;
using Shadower.Services.Interfaces;
using Shadower.Web.Models;

namespace Shadower.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public IActionResult Tracked()
        {
            return this.View();
        }

        // TODO: Filter archived
        [HttpGet]
        public IActionResult GetImportant()
        {
            var important = this.postService.GetImportant().Select(p => new PostListViewModel
            {
                Id = p.Id,
                Link = p.Link,
                UploadedDateTime = p.UploadDateTime
            }).ToList();

            return this.Json(important);
        }

        [HttpPost]
        public IActionResult Archive(int id)
        {
            this.postService.ArchivePost(id);

            return this.Ok();
        }
    }
}