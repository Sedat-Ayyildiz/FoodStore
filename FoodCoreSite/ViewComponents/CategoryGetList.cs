using FoodCoreSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodCoreSite.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categorylist = categoryRepository.TList();
            return View(categorylist);
        }
    }
}
