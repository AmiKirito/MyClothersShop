using MyClothersShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public interface IClothRepository
    {
        Cloth GetCloth(int Id);
        IEnumerable<Cloth> GetAllClothers();
        IEnumerable<Image> GetAllImages();
        IEnumerable<ClothImages> GetAllClothImages();
        Cloth Add(Cloth cloth);
        Cloth Update(Cloth clothChange);
        Cloth Delete(int id);
    }
}
