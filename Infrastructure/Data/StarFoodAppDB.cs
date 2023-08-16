using Microsoft.EntityFrameworkCore;
using Star.FoodApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StarFoodAppDB : DbContext  
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantFood> RestaurantFoods { get; set; }
        public StarFoodAppDB(DbContextOptions<StarFoodAppDB> options)
            :base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasKey(a => a.Username);
        }
    }
}
