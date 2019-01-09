using System.Collections.Generic;
using Songrics.Services.Models.Categories;

namespace Songrics.Services.DataServices
{
    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        bool IsCategoryIdValid(int categoryId);

        int? GetCategoryId(string name);
    }
}