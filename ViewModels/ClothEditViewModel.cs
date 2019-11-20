using MyClothersShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.ViewModels
{
    public class ClothEditViewModel : ClothCreateViewModel
    {
        public int ClothId { get; set; }
        public List<Image> ExistingImages { get; set; }
    }
}
