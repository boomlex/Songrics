using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Songrics.Data.Models;
using Songrics.Services.Data;
using Songrics.Services.Models.Lyrics;
using X.PagedList;

namespace Songrics.Web.Controllers
{
    [Authorize]  
    public class UserController : BaseController
    {
        
        private readonly LyricsServices lyricsServices;
        private readonly IMapper mapper;
        private SignInManager<SongricsUser> signInManager;

        public UserController(
            IMapper mapper,
            LyricsServices lyricsServices,
            SignInManager<SongricsUser> signInManager)
        {
            this.mapper = mapper;
            this.lyricsServices = lyricsServices;

            this.signInManager = signInManager;
        }

        [Route("User")]
        public async Task<IActionResult> Userr(int? page)
        {
            var lyrics = this.lyricsServices.allLyrics();
           
            var viewModel = new List<LyricDetailsViewModel>();

            var userId = signInManager.UserManager.GetUserId(User);

           
            foreach (var item in lyrics)
            {
                if (item.UserId == userId)
                {
                    var lyricViewModel = this.mapper.Map<LyricDetailsViewModel>(item);
                    viewModel.Add(lyricViewModel);
                }
            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 4);


            return View(pagedViewModels);
        }
    }
}
