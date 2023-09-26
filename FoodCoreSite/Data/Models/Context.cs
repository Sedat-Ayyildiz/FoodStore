using Microsoft.EntityFrameworkCore;

namespace FoodCoreSite.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = SEDAT-AYYILDIZ; Database = DbFoodCore; Integrated Security = True; TrustServerCertificate = True");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
