using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return cars.FirstOrDefault(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
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
