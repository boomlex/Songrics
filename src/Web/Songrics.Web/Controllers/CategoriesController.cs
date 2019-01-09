using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Songrics.Services.DataServices;
using X.PagedList;

namespace Songrics.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly ILyricsService lyricsService;

        public CategoriesController(
            ICategoriesService categoriesService,
            ILyricsService jokesService)
        {
            this.categoriesService = categoriesService;
            this.lyricsService = jokesService;
        }

        public IActionResult Index()
        {
            var categories = categoriesService
                .GetAll()
                .ToList();

            return this.View(categories);
        }

        public IActionResult Details(int id, int? page)
        {
            var lyricsInCategory = this.lyricsService.GetAllByCategory(id).ToList();

            var nextPage = page ?? 1;

            var pagedLyrics = lyricsInCategory.ToPagedList(nextPage, 4);

            return this.View(pagedLyrics);
        }
    }
}
