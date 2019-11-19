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
            modelBuilder.Entity<ClothImages>()
                .HasKey(cl => new { cl.ImageId, cl.ClothId });
            modelBuilder.Entity<ClothImages>()
                .HasOne(cl => cl.Cloth)
                .WithMany(c => c.Images)
                .HasForeignKey(cl => cl.ClothId);
            modelBuilder.Entity<ClothImages>()
                .HasOne(cl => cl.Image)
                .WithMany(c => c.Clothers)
                .HasForeignKey(bc => bc.ClothId);

            var clothers = new List<Cloth>
            {
                new Cloth
                {
                    ClothId = 1,
                    Title = "T-Short",
                    Price = 300,
                    Description = "Description about T-Short"
                },
                new Cloth
                {
                    ClothId = 2,
                    Title = "Jeans",
                    Price = 300,
                    Description = "Description about Jeans"
                }
            };
            var images = new List<Image>
            {
                new Image
                {
                    ImageId = 1,
                    PhotoPath = "original_images/jeans.jpg"
                },
                new Image
                {
                    ImageId = 2,
                    PhotoPath = "original_images/logo.png"
                }
            };

            var clothersImages = new List<ClothImages>
            {
                new ClothImages{ImageId = 1, ClothId = 1},
                new ClothImages{ImageId = 1, ClothId = 2},
                new ClothImages{ImageId = 2, ClothId = 1},
                new ClothImages{ImageId = 2, ClothId = 2}
            };


            modelBuilder.Entity<ClothImages>().HasData(clothersImages);
            modelBuilder.Entity<Cloth>().HasData(clothers);
            modelBuilder.Entity<Image>().HasData(images);
        }
    }
}
