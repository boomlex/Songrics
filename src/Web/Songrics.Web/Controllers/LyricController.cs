using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Songrics.Data;
using Songrics.Data.Models;
using Songrics.Services.Data;
using CreateLyricInputModel = Songrics.Web.Model.Lyric.CreateLyricInputModel;

namespace Songrics.Web.Controllers
{
    [Route("Create-Lyrics")]
    public class LyricController : BaseController
    {
        private readonly UserManager<SongricsUser> userManager;
        private readonly SongricsContext songricsContext;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserRoles userRoles;

        public LyricController(
            RoleManager<IdentityRole> roleManager,
            UserManager<SongricsUser> userManager,
            SongricsContext songricsContext,
            UserRoles userRoles
            )
        {
            this.userManager = userManager;
            this.songricsContext = songricsContext;
            this.roleManager = roleManager;
            this.userRoles = userRoles;
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

            var user = await userManager.GetUserAsync(User);

            var lyric = new Lyric()
            {
                Title = input.Title,
                ArtistName = input.ArtistName,
                AlbumName = input.AlbumName,
                Category = input.Category,
                VideoLink = input.VideoLink,
                SongLyric = input.SongLyric,
                User = input.User,

            };
            songricsContext.Add(lyric);
            songricsContext.SaveChanges();
            return this.RedirectToAction("Index", "Home");

        }

        // public IActionResult Details(int id)
        // {
        //     var lyric = this.LyricsService.GetLyricById<LyricDetailsViewModel>(id);
        //     return this.View(lyric);
        // }

        //[HttpPost]
        //public object RateLyric(int lyricId, int rating)
        //{
        //    var rateLyric = this.lyricsService.AddRatingToLyric(lyricId, rating);
        //    if (!rateLyric)
        //    {
        //        return Json($"An error occurred while processing your vote");
        //    }
        //    var successMessage = $"You successfully rated the lyric with rating of {rating}";
        //    return Json(successMessage);
        //}
    }
}
