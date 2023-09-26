using System.ComponentModel.DataAnnotations;

namespace FoodCoreSite.Data.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required(ErrorMessage = "Food Name Not Empty!")]
        [StringLength(20, ErrorMessage = "Please only enter 4-20 length characters!", MinimumLength = 4)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Food Description Not Empty!")]
        [StringLength(200, ErrorMessage = "Please only enter 50-200 length characters!", MinimumLength = 50)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Food Price Not Empty!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Food ImageUrl Not Empty!")]
        [StringLength(200, ErrorMessage = "Please only enter 10-200 length characters!", MinimumLength = 10)]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Food Stock Not Empty!")]
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
