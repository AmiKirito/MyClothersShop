using MyClothersShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.ViewModels
{
    public class AllDataViewModel
    {
        public List<Cloth> clothers { get; set; }
        public List<Image> images { get; set; }
        public List<ClothImages> clothImages { get; set; }
    }
}
