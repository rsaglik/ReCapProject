using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        bool Add(Brand brand);
        bool Delete(Brand brand);
        void Update(Brand brand);
    }
}
