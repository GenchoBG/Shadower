using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shadower.Services;
using Shadower.Services.Interfaces;
using Shadower.Web.Models;

namespace Shadower.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService facesService;

        public PostsController(IPostService facesService)
        {
            this.facesService = facesService;
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
            var important = this.facesService.GetImportant().Select(p => new PostListViewModel
            {
                Id = p.Id,
                Link = p.Link,
                UploadedDateTime = p.UploadDateTime
            }).ToList();

            return this.Json(important);
        }
    }
}