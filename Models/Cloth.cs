using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
    public enum BootstrapAlertType
    {
        Plain,
        Success,
        Information,
        Warning,
        Danger,
        Primary,
    }

}
