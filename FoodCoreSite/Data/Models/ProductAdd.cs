using System.ComponentModel.DataAnnotations;

namespace FoodCoreSite.Data.Models
{
    public class ProductAdd
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
