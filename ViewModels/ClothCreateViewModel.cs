using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.ViewModels
{
    public class ClothCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Description { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
