using Microsoft.AspNetCore.Hosting;
using MyClothersShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public class SqlClothRepository : IClothRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SqlClothRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public Cloth Add(Cloth cloth)
        {
            context.Clothers.Add(cloth);
            context.SaveChanges();
            return cloth;
        }

        public Cloth Delete(int id)
        {
            Cloth cloth = context.Clothers.Find(id);
            if (cloth != null)
            {
                if (cloth.Images != null)
                {
                    //foreach (Image image in cloth.Images)
                    //{
                    //    string filePath = System.IO.Path.Combine(_webHostEnvironment.WebRootPath, "images", image.PhotoPath);
                    //    System.IO.File.Delete(filePath);
                    //}
                }
                context.Clothers.Remove(cloth);
                context.SaveChanges();
            }
            return cloth;
        }

        public Cloth Update(Cloth clothChange)
        {
            var cloth = context.Clothers.Attach(clothChange);
            cloth.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return clothChange;
        }
        public Cloth GetCloth(int Id)
        {
            return context.Clothers.Find(Id);
        }

        public IEnumerable<Cloth> GetAllClothers()
        {
            return context.Clothers;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return context.Images;
        }

        public IEnumerable<ClothImages> GetAllClothImages()
        {
            return context.ClothersImages;
        }
    }
}
