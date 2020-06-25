using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Shadower.Data.Models;
using Shadower.Services;
using Shadower.Services.Interfaces;
using Shadower.Web.Hubs;
using Shadower.Web.Models;

namespace Shadower.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly IHubContext<NotificationsHub> hubContext;

        public HomeController(IPostService postService, IHubContext<NotificationsHub> hubContext)
        {
            this.postService = postService;
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(PostAddModel model)
        {
            if (model.Embeddings.Count == 0)
            {
                return this.BadRequest();
            }

            var embeddingsArray = model.Embeddings.Select(e => e.ToArray()).ToArray();

            Post post;

            if (embeddingsArray[0].Length != 128)
            {
                var embeddings = new List<List<double>>(embeddingsArray[0].Length);

                var flattened = model.Embeddings.SelectMany(l => l).ToArray();

                var current = new List<double>();
                for (int i = 0; i <= flattened.Length; i++)
                {
                    if (i != 0 && i % 128 == 0)
                    {
                        embeddings.Add(current);
                        current = new List<double>();
                        if (i == flattened.Length)
                        {
                            break;
                        }
                    }

                    current.Add(flattened[i]);
                }

                post = this.postService.AddPost(model.Link, embeddings);
            }
            else
            {
                post = this.postService.AddPost(model.Link, model.Embeddings);
            }

            if (post.Faces.Any(f => f.Face.Tracked))
            {
                await this.hubContext.Clients.All.SendCoreAsync("DisplayNotification", new object[] { });
                await this.hubContext.Clients.All.SendCoreAsync("UpdateFoundFaces", new object[] { DateTime.Now, model.Link, post.Id });
            }

            return this.Ok();
        }

        [HttpPost]
        public IActionResult SearchFace(FaceSearchModel model)
        {
            var posts = this.postService.FindPostsByEmbedding(model.Embedding);

            return this.Json(posts);
        }

        [HttpPost]
        public IActionResult ShouldNotify(FaceSearchModel model)
        {
            var isSuccessful = this.postService.AddTrackedFace(model.Embedding);

            return this.Json(new { success = isSuccessful });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult InstructionManual()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
