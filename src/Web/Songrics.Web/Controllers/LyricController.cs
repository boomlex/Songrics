using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Songrics.Services.DataServices;
using Songrics.Web.Model.Lyric;
using Songrics.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Songrics.Services.Models.Lyrics;
using CreateLyricInputModel = Songrics.Web.Model.Lyric.CreateLyricInputModel;

namespace Songrics.Services.Controllers
{
    public class LyricController : BaseController
    {
        private readonly ILyricsService lyricsService;
        private readonly ICategoriesService categoriesService;

        public LyricController(
            ILyricsService jokesService,
            ICategoriesService categoriesService)
        {
            this.lyricsService = jokesService;
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.NameAndCount,
                });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLyricInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.lyricsService.Create(input.Title, input.ArtistName, input.AlbumName, input.CategoryId, input.VideoLink, input.SongLyric);
            return this.RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var lyric = this.lyricsService.GetLyricById<LyricDetailsViewModel>(id);
            return this.View(lyric);
        }

        [HttpPost]
        public object RateLyric(int lyricId, int rating)
        {
            var rateLyric = this.lyricsService.AddRatingToLyric(lyricId, rating);
            if (!rateLyric)
            {
                return Json($"An error occurred while processing your vote");
            }
            var successMessage = $"You successfully rated the lyric with rating of {rating}";
            return Json(successMessage);
        }
    }
}
