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
        Cloth Add(Cloth cloth);
        Cloth Update(Cloth clothChange);
        Cloth Delete(int id);
    }
}
