using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string PhotoPath { get; set; }
        public int ClothId { get; set; }
        public Cloth Cloth { get; set; }
    }
}
