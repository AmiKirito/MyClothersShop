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

namespace MyClothersShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClothRepository _clothRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IClothRepository clothRepository, IWebHostEnvironment hostingEnvironment)
        {
            _clothRepository = clothRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var model = _clothRepository.GetAllClothers();
            return View(model);
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
                string uniquieFileName = ProcessUploadedFile(model);
                Cloth cloth = new Cloth
                {
                    Title = model.Title,
                    Price = model.Price,
                    Description = model.Description,
                    PhotoPath = uniquieFileName
                };

                _clothRepository.Add(cloth);
                Alert("The product was created successfully!", NotificationType.success);
                return RedirectToAction("details", new { id = cloth.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cloth cloth = _clothRepository.GetCloth(id);
            ClothEditViewModel employeeEditViewModel = new ClothEditViewModel
            {
                Id = cloth.Id,
                Title = cloth.Title,
                Price = cloth.Price,
                Description = cloth.Description,
                ExistingPhotoPath = cloth.PhotoPath
            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ClothEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                Cloth cloth = _clothRepository.GetCloth(model.Id);
                cloth.Title = model.Title;
                cloth.Price = model.Price;
                cloth.Description = model.Description;

                if(model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    cloth.PhotoPath = ProcessUploadedFile(model);
                }
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
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Cloth = _clothRepository.GetCloth(id ?? 1),
                Title = "Cloth Details"
            };
            return View(homeDetailsViewModel);
        }
        private string ProcessUploadedFile(ClothCreateViewModel model)
        {
            string uniquieFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniquieFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniquieFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniquieFileName;
        }
        public void Alert(string message, NotificationType notificationType)
        {
            var msg = message;
            TempData["notification"] = msg;
        }
    }
}
