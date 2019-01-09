using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Songrics.Data;
using Songrics.Services.Data;
using Songrics.Services.Models;
using Songrics.Services.Models.Lyrics;
using X.PagedList;

namespace Songrics.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {

        private SongricsContext songricsContext;
        private readonly LyricsServices lyricsServices;
        private readonly IMapper mapper;


        public HomeController(SongricsContext songricsContext,
            LyricsServices lyricsServices,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.lyricsServices = lyricsServices;
            this.songricsContext = songricsContext;
        }


        public IActionResult Index(int? page)
        {
            var receipts = this.lyricsServices.allLyrics();
            var viewModel = new List<LyricDetailsViewModel>();

            foreach (var item in receipts)
            {
                var lyricViewModel = this.mapper.Map<LyricDetailsViewModel>(item);
                viewModel.Add(lyricViewModel);
            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 8);


            return View(pagedViewModels);


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
