using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Songrics.Data;
using Songrics.Data.Models;
using Songrics.Services.Data;
using Songrics.Services.Models.Lyrics;
using Songrics.Web.Model.Lyric;

namespace Songrics.Web.Controllers
{
    public class LyricManagerController : BaseController
    {
        private readonly UserManager<SongricsUser> userManager;
        private readonly SongricsContext songricsContext;
        private readonly LyricsServices lyricsServices;
        private readonly IMapper mapper;

        public LyricManagerController(
            IMapper mapper,
            LyricsServices lyricsServices,
        UserManager<SongricsUser> userManager,
            SongricsContext songricsContext)
        {
            this.userManager = userManager;
            this.songricsContext = songricsContext;
            this.lyricsServices = lyricsServices;
            this.mapper = mapper;
        }

        [Authorize]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["id"] = id;
            var lyricsUserId = userManager.GetUserId(User);
            var lyrics = this.lyricsServices.allLyrics();
            foreach (var item in lyrics)
            {
                if (item.UserId == lyricsUserId && item.Id == id)
                {
                    var lyricViewModel = this.mapper.Map<LyricDetailsViewModel>(item);
                    return View(lyricViewModel);
                }
            }
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(CreateLyricInputModel input)
        {
            var lyricUserId = userManager.GetUserId(User);
            var user = await userManager.GetUserAsync(User);
            var lyrics = this.lyricsServices.allLyrics();
            var idCk = TempData["id"];
            var id = Convert.ToInt32(idCk);
            var viewModel = new List<LyricDetailsViewModel>();
            var recToUpdate = songricsContext.Lyrics.SingleOrDefault(x => x.Id == id);
            foreach (var item in lyrics)
            {
                if (idCk.ToString() == item.Id.ToString() && item.UserId == lyricUserId)
                {
                    var lyric = new Lyric()
                    {
                        Id = id,
                        Title = input.Title,
                        ArtistName = input.ArtistName,
                        AlbumName = input.AlbumName,
                        Category = input.Category,
                        VideoLink = input.VideoLink,
                        SongLyric = input.SongLyric,
                        User =user,
                    };
                    songricsContext.Lyrics.Remove(recToUpdate);
                    songricsContext.Lyrics.Add(lyric);
                }
            }
            songricsContext.SaveChanges();
            return this.RedirectToAction("Userr", "User");
        }


        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var lyrics = this.lyricsServices.allLyrics();
            var viewModel = new List<LyricSimpleViewModel>();
            foreach (var item in lyrics)
            {
                if (item.Id == id)
                {
                    var receiptViewModel = this.mapper.Map<LyricSimpleViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }
            }
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var recToUpdate = songricsContext.Lyrics.SingleOrDefault(x => x.Id == id);
            songricsContext.Lyrics.Remove(recToUpdate);
            songricsContext.SaveChanges();
            return View();
        }
    }
}
