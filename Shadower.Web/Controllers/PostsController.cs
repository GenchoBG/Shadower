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
        public IActionResult Tracked(string archived = "false")
        {
            this.ViewData["archived"] = archived;

            return this.View();
        }

        // TODO: Filter archived
        [HttpGet]
        public IActionResult GetImportant(string archived)
        {
            var postsQuery = this.postService.GetImportant();

            if (string.IsNullOrWhiteSpace(archived))
            {
                postsQuery = postsQuery.Where(p => !p.Archived);
            }

            var important = postsQuery.Select(p => new PostListViewModel
            {
                Id = p.Id,
                Link = p.Link,
                UploadedDateTime = p.UploadDateTime,
                Archived = p.Archived
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