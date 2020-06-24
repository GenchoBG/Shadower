using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shadower.Services.Interfaces;

namespace Shadower.Web.Controllers
{
    public class FacesController : Controller
    {
        private readonly IFacesService facesService;

        public FacesController(IFacesService facesService)
        {
            this.facesService = facesService;
        }

        public IActionResult Tracked()
        {
            return View();
        }
    }
}