using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car1 = new Car { 
                Id =1,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 125500,
                Description = "Temiz araç",
                ModelYear = 2016
            };
            carManager.Add(car1);


            Car car2 = new Car
            {
                Id = 2,
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 325500,
                Description = "Sahibinden Temiz Araç",
                ModelYear = 2019
            };
            carManager.Add(car2);

            Car car3 = new Car
            {
                Id = 3,
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 65500,
                Description = "Hata Kaza Değişen Yok! Sadece 2 parça boyalı geyik çarptı :)",
                ModelYear = 2009
            };
            carManager.Add(car3);

            car1.ModelYear = 2015;
            carManager.Update(car1);

            //Delete
            carManager.Delete(car2);

            //List Cars
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine($"Color Id : {item.ColorId}, Model Year : {item.ModelYear}, Daily Price : {item.DailyPrice.ToString("n2")}");
            }

        }
    }
}
