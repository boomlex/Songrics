using System.Collections.Generic;
using System.Linq;
using Songrics.Data.Common;
using Songrics.Data.Models;
using Songrics.Services.Mapping;
using Songrics.Services.Models.Categories;

namespace Songrics.Services.DataServices
{
    public class CategoriesService :ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All().OrderBy(x => x.Name)
                .To<CategoryIdAndNameViewModel>()
                .ToList();

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }

        public int? GetCategoryId(string name)
        {
            var category = this.categoriesRepository.All().FirstOrDefault(x => x.Name == name);
            return category?.Id;
        }
    }
}
