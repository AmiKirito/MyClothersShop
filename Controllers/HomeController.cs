using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using MyClothersShop.Models;
using MyClothersShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static MyClothersShop.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MyClothersShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dBContext;

        private readonly IClothRepository _clothRepository;

        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IClothRepository clothRepository, AppDbContext dBContext,
                              IWebHostEnvironment hostingEnvironment)
        {
            _dBContext = dBContext;
            _clothRepository = clothRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var model = _dBContext.Clothers
                        .Include(c => c.Images)
                        .ToArray();
            
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            var model = _dBContext.Clothers
                        .Include(c => c.Images)
                        .ToArray();
            HomeDetailsViewModel allDataViewModel = new HomeDetailsViewModel()
            {
                Title = "Cloth Details",   
            };

            allDataViewModel.Cloth = model.Where(x => x.ClothId == id).FirstOrDefault();

            return View(allDataViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ClothCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                List<Image> uniquieFileNames = ProcessUploadedFile(model);
                Cloth cloth = new Cloth
                {
                    Title = model.Title,
                    Price = model.Price,
                    Description = model.Description,
                    Images = uniquieFileNames
                };
                _clothRepository.Add(cloth);
                Alert("The product was created successfully!", NotificationType.success);
                return RedirectToAction("details", new { id = cloth.ClothId });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _clothRepository.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _dBContext.Clothers
                        .Include(c => c.Images)
                        .ToArray();

            Cloth cloth = _clothRepository.GetCloth(id);

            ClothEditViewModel clothEditViewModel = new ClothEditViewModel
            {
                ClothId = cloth.ClothId,
                Title = cloth.Title,
                Price = cloth.Price,
                Description = cloth.Description,
                ExistingImages = new List<Image>()
            };

            foreach (var image in model.Where(x => x.ClothId == id).FirstOrDefault().Images)
            {
                clothEditViewModel.ExistingImages.Add(image);
            }

            return View(clothEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ClothEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                Cloth cloth = _clothRepository.GetCloth(model.ClothId);
                cloth.Title = model.Title;
                cloth.Price = model.Price;
                cloth.Description = model.Description;

                //if (model.Photo != null)
                //{
                //    if (model.ExistingPhotoPath != null)
                //    {
                //        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                //        System.IO.File.Delete(filePath);
                //    }
                //    cloth.PhotoPath = ProcessUploadedFile(model);
                //}
                _clothRepository.Update(cloth);
                return RedirectToAction("index");
            }
            return View();
        }
        private List<Image> ProcessUploadedFile(ClothCreateViewModel model)
        {
            List<Image> uniqueImages = new List<Image>();

            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    Image image = new Image();
                    string uniquieFileName = "";

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniquieFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniquieFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                    image.PhotoPath = uniquieFileName;
                    uniqueImages.Add(image);
                }
            }

            return uniqueImages;
        }
        public void Alert(string message, NotificationType notificationType)
        {
            var msg = message;
            TempData["notification"] = msg;
        }
    }
}
