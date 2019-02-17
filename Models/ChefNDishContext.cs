using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Models
{
    public class ChefNDishContext: DbContext{
        public ChefNDishContext(DbContextOptions<ChefNDishContext> options) : base(options) {}

        public DbSet<Chef> MyChefs {get; set;}
        public DbSet<Dish> MyDishes {get; set;}
    }
}