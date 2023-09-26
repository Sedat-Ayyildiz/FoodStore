using FoodCoreSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodCoreSite.ViewComponents
{
    public class FoodGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodlist = foodRepository.TList();
            return View(foodlist);
        }
    }
}
