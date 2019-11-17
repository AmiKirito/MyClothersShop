using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClothersShop.Models
{
    public class ImplClothRepository : IClothRepository
    {
        private readonly List<Cloth> _clothList;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ImplClothRepository()
        {
            _clothList = new List<Cloth>()
            {
                new Cloth() {Id = 1, Title = "Jeans", Price = 100, Description = "Daily routine cloth" },
                new Cloth() {Id = 2, Title = "T-Short", Price = 200, Description = "You can wear it anywhere" },
                new Cloth() {Id = 3, Title = "Cap", Price = 150, Description = "Cool summer cap" },
                new Cloth() {Id = 4, Title = "Trousers", Price = 300, Description = "For important meetings" },
                new Cloth() {Id = 5, Title = "Jacket", Price = 600, Description = "Cool & cheap" },
                new Cloth() {Id = 6, Title = "Blouse", Price = 250, Description = "COmfortable for any occasion" }
            };
        }
        public Cloth GetCloth(int Id)
        {
            return _clothList.FirstOrDefault(e => e.Id == Id);
        }
        public IEnumerable<Cloth> GetAllClothers()
        {
            return _clothList;
        }

        public Cloth Add(Cloth cloth)
        {
            cloth.Id = _clothList.Max(e => e.Id) + 1;
            _clothList.Add(cloth);
            return cloth;
        }

        public Cloth Edit(Cloth clothChange)
        {
            throw new NotImplementedException();
        }

        public Cloth Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cloth Update(Cloth clothChange)
        {
            throw new NotImplementedException();
        }
    }
}
