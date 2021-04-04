using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car>();
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteToCar = cars.FirstOrDefault(c => c.Id == car.Id);
            if(deleteToCar != null)
            {
                cars.Remove(deleteToCar);
            }
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public Car GetById(int Id)
        {
            return cars.FirstOrDefault(c => c.Id == Id);
        }

        public void Update(Car car)
        {
            var updateToCar = cars.FirstOrDefault(c => c.Id == car.Id);
            if (updateToCar != null)
            {
                updateToCar.BrandId = car.BrandId;
                updateToCar.ColorId = car.ColorId;
                updateToCar.DailyPrice = car.DailyPrice;
                updateToCar.Description = car.Description;
                updateToCar.ModelYear = car.ModelYear;
            }
        }
    }
}
