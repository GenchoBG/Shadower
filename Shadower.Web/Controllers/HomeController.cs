using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Shadower.Services;
using Shadower.Web.Models;

namespace Shadower.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddPost(PostAddModel model)
        {
            if (model.Embeddings.Count == 0)
            {
                return this.BadRequest();
            }

            var embeddingsArray = model.Embeddings.Select(e => e.ToArray()).ToArray();

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

                this.postService.AddPost(model.Link, embeddings);
            }
            else
            {
                this.postService.AddPost(model.Link, model.Embeddings);
            }

            return this.Ok();
        }

        [HttpPost]
        public IActionResult SearchFace(FaceSearchModel model)
        {
            var posts = this.postService.FindPostsByEmbedding(model.Embedding);

            return this.Json(posts);
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
