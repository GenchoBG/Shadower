﻿using System;
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

        public IActionResult SearchFace(IList<double> embedding)
        {
            var posts = this.postService.FindPostsByEmbedding(embedding);

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
