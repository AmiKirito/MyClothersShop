using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyClothersShop.Models;

namespace MyClothersShop.Models
{
    public class ClothImages
    {
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; }
        public int ImageId { get;set; }
        public Image Image { get; set; }
    }
}
