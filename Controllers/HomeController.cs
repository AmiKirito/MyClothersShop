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

namespace MyClothersShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClothRepository _clothRepository;
        private readonly IClothRepository _imagesRepository;
        private readonly IClothRepository _clothImagesRepository;

        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IClothRepository clothRepository, IClothRepository imagesRepository,
                              IClothRepository clothImagesRepository, IWebHostEnvironment hostingEnvironment)
        {
            _clothRepository = clothRepository;
            _imagesRepository = imagesRepository;
            _clothImagesRepository = clothImagesRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            AllDataViewModel allDataViewModel = GetAllData();

            return View(allDataViewModel);
        }

        private AllDataViewModel GetAllData()
        {
            return new AllDataViewModel()
            {
                clothers = _clothRepository.GetAllClothers().ToList(),
                images = _imagesRepository.GetAllImages().ToList(),
                clothImages = _clothImagesRepository.GetAllClothImages().ToList()
            };
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel allDataViewModel = new HomeDetailsViewModel()
            {
                Title = "Cloth Details",   
            };
            allDataViewModel.Cloth = _clothRepository.GetCloth(id ?? 1);
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
                List<ClothImages> uniquieFileNames = ProcessUploadedFile(model);
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cloth cloth = _clothRepository.GetCloth(id);

            ClothEditViewModel clothEditViewModel = new ClothEditViewModel
            {
                ClothId = cloth.ClothId,
                Title = cloth.Title,
                Price = cloth.Price,
                Description = cloth.Description,
            };

            ExistingImage existing = null;

            foreach (ClothImages image in cloth.Images)
            {
                //  existing.ExistingPhotoPath = image.PhotoPath;
                clothEditViewModel.ExistingPaths.Add(existing);
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
        public IActionResult Delete(int id)
        {
            _clothRepository.Delete(id);
            return RedirectToAction("index");
        }
        private List<ClothImages> ProcessUploadedFile(ClothCreateViewModel model)
        {
            List<ClothImages> uniqueImages = null;
            ClothImages image = null;
            string uniquieFileName = null;

            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniquieFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniquieFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
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
