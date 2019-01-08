using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Songrics.Services.DataServices;
using Songrics.Web.Model.Lyric;
using Songrics.Web.Controllers;
using CreateLyricInputModel = Songrics.Web.Model.Lyric.CreateLyricInputModel;

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
        public async Task<IActionResult> Create(CreateLyricInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var CreateId = await this.lyricsService.Create(input.Title, input.ArtistName, input.AlbumName, input.VideoLink, input.SongLyric);
            return this.RedirectToAction("Details", new { id = 0 });
        }


        public IActionResult Details(int id)
        {
            var lyric = this.lyricsService.GetLyricById(id);
            return this.View(lyric);
        }
    }
}
