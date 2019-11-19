using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClothersShop.Models;
using MyClothersShop.ViewModels;

namespace MyClothersShop.ViewModels
{
    public class HomeDetailsViewModel
    {
        //public AllDataViewModel allData { get; set; }
        public Cloth Cloth { get; set; }
        public string Title { get; set; }
    }
}
