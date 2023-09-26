using System.ComponentModel.DataAnnotations;

namespace FoodCoreSite.Data.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
