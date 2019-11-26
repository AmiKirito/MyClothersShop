using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        public string Extensions { get;set; }

        public override bool IsValid(object value)
        {
            List<IFormFile> photos = value as List<IFormFile>;

            if(photos != null)
            {
                foreach (var photo in photos)
                {
                    string ext = Path.GetExtension(photo.FileName);

                    ext = ext.TrimStart('.');

                    return Extensions.Contains(ext);
                }
            }
            return true;
        }
    }
}
