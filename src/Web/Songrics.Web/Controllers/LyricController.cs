using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Songrics.Services.DataServices;
using Songrics.Services.Models;
using Songrics.Services.Models.Home;
using Songrics.Services.Models.Lyric;
using Songrics.Web.Controllers;

namespace Songrics.Services.Controllers
{
    public class LyricController : BaseController
    {
        private readonly ILyricsService lyricsService;

        public LyricController(ILyricsService lyricsService)
        {
            this.lyricsService = lyricsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateLyricInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var CreateId = this.lyricsService.Create(input);
            return this.RedirectToAction("Details", new { id = 0 });
        }


        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}
