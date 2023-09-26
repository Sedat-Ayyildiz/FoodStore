using System.ComponentModel.DataAnnotations;

namespace FoodCoreSite.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name Not Empty!")]
        [StringLength(20, ErrorMessage = "Please only enter 4-20 length characters!", MinimumLength = 4)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category Description Not Empty!")]
        [StringLength(200, ErrorMessage = "Please only enter 10-200 length characters!", MinimumLength = 10)]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }

        public List<Food> Foods { get; set; }
    }
}
