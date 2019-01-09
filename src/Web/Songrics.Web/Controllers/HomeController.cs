using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Songrics.Services.DataServices;
using Songrics.Services.Models;
using Songrics.Services.Models.Home;

namespace Songrics.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILyricsService lyricsService;

        public HomeController(ILyricsService lyricsService)
        {
            this.lyricsService = lyricsService;
        }

        public IActionResult Index(int id)
        {
            var lyrics = this.lyricsService.PostLyric(20);
            var viewModel = new IndexViewModel
            {
                Lyrics = lyrics,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
