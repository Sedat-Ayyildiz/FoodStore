using FoodCoreSite.Data.Models;
using FoodCoreSite.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FoodCoreSite.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 5));
        }

        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }

        [HttpPost]
        public IActionResult FoodAdd(ProductAdd p)
        {
            Food f=new Food();
            if (p.ImageUrl!=null)
            {
                var extension = Path.GetExtension(p.ImageUrl.FileName);// bu işlemin gerçekleşmesi için veri türü 'IFormFile' olmalı !
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Images/",newimagename);
                var stream=new FileStream(location,FileMode.Create);
                p.ImageUrl.CopyTo(stream);
                f.ImageUrl = newimagename;
            }
            f.Name= p.Name;
            f.Price= p.Price;
            f.Stock= p.Stock;
            f.CategoryId= p.CategoryId;
            f.Description= p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult FoodDelete(int id)
        {
            foodRepository.TRemove(new Food { FoodId = id });
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);

            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;

            Food f = new Food()
            {
                FoodId = x.FoodId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            };
            return View(f);
        }

        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodId);
            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageUrl = p.ImageUrl;
            x.Description = p.Description;
            x.CategoryId = p.CategoryId;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
