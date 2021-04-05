using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public bool Add(Car car)
        {
            if(car.Description.Length < 2)
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır!");
                return false;
            }

            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalıdır!");
                return false ;
            }

            _carDal.Add(car);
            Console.WriteLine($"Araç bilgisi eklendi");
            return true;
        }

        public bool Delete(Car car)
        {
            _carDal.Delete(car);
            return true;
        }

        public List<Car> GetAll()
        {
            //iş kodları
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }
        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
