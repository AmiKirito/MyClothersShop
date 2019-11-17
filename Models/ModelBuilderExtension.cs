using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cloth>().HasData(
                new Cloth
                {
                    Id = 1,
                    Title = "T-Short",
                    Price = 150,
                    Description = "You can wear it anyhwere"
                },
                new Cloth
                {
                    Id = 2,
                    Title = "Jeans",
                    Price = 300,
                    Description = "This jeans are very comfortable for any occasion"
                }
                );
        }
    }
}
