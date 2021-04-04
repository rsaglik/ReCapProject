﻿using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            _carDal.Add(car);
            Console.WriteLine($"Araç bilgisi eklendi");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine($"Araç bilgileri silindi");
        }

        public List<Car> GetAll()
        {
            //iş kodları
            return _carDal.GetAll();
        }

        public Car GetById(int  Id)
        {
            return _carDal.GetById(Id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine($"Araç bilgileri güncellendi");
        }
    }
}