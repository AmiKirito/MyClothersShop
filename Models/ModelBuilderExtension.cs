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
            modelBuilder.Entity<Image>()
                .HasOne<Cloth>(c => c.Cloth)
                .WithMany(i => i.Images)
                .HasForeignKey(c => c.ClothId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cloth>()
                .HasData(
                    new Cloth
                    {
                        ClothId = 1,
                        Title = "T-Short",
                        Price = 250,
                        Description = "You just can wear it anywhere :)"

                    },
                    new Cloth
                    {
                        ClothId = 2,
                        Title = "Jeans",
                        Price = 500,
                        Description = "Really comfortable and suits for any occasion"
                    }
                );
           
            modelBuilder.Entity<Image>()
                .HasData(
                    new Image
                    {
                        ImageId = 1,
                        PhotoPath = "original_images/t-short.jpg",              
                        ClothId = 1
                    },
                    new Image
                    {
                        ImageId = 2,
                        PhotoPath = "original_images/jeans.jpg",
                        ClothId = 2
                    },
                    new Image
                    {
                        ImageId = 3,
                        PhotoPath = "original_images/logo.png",
                        ClothId = 1
                    },
                    new Image
                    {
                        ImageId = 4,
                        PhotoPath = "original_images/test.png",
                        ClothId = 2
                    }
                );
        }
    }
}
