using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand
            {
                Name = "Fiat"
            };
            Brand brand2 = new Brand
            {
                Name = "Ford"
            };
            Brand brand3 = new Brand
            {
                Name = "Toyota"
            };
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            brandManager.Add(brand3);


            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color
            {
                Name = "Kırmızı"
            };
            Color color2 = new Color
            {
                Name = "Beyaz"
            };
            Color color3 = new Color
            {
                Name = "Gri"
            };
            colorManager.Add(color1);
            colorManager.Add(color2);
            colorManager.Add(color3);


            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 125500,
                Description = "Temiz araç",
                ModelYear = 2016
            };
            carManager.Add(car1);


            Car car2 = new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 325500,
                Description = "Sahibinden Temiz Araç",
                ModelYear = 2019
            };
            carManager.Add(car2);

            Car car3 = new Car
            {
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 65500,
                Description = "Hata Kaza Değişen Yok! Sadece 2 parça boyalı geyik çarptı :)",
                ModelYear = 2009
            };
            carManager.Add(car3);

            //update
            car1.ModelYear = 2015;
            carManager.Update(car1);

            //Delete
            carManager.Delete(car2);

            //List Cars
            foreach (var item in carManager.GetCarDetailDtos())
            {
                Console.WriteLine($"Car Name : {item.CarName}, Brand Name : {item.BrandName}, Color Name : {item.ColorName}, Daily Price : {item.DailyPrice.ToString("n2")}");
            }




        }
    }
}
