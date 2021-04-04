using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        bool Add(Color color);
        bool Delete(Color color);
        void Update(Color color);
    }
}
