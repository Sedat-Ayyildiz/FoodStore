using FoodCoreSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodCoreSite.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            //id = 1;
            FoodRepository foodRepository = new FoodRepository();
            var foodlist = foodRepository.List(x => x.CategoryId == id);
            return View(foodlist);
        }
    }
}
