using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AracEkle();

            UserManager userManager = new UserManager(new EfUserDal());
            var userList = userManager.GetAll();
            if (!userList.Data.Any())
            {
                User user = new User
                {
                    Email = "info@xyz.com",
                    FirstName = "Ahmet",
                    LastName = "Yıldız",
                    Status = true,
                };
                userManager.Add(user);
                userList = userManager.GetAll();
            }

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var customerList = customerManager.GetAll();
            if (!customerList.Data.Any())
            {
                Customer customer = new Customer
                {
                    UserId = userList.Data.Single().Id,
                    CompanyName = "XYZ A.Ş"
                };
                customerManager.Add(customer);
                customerList = customerManager.GetAll();
            }

            var carManager = new CarManager(new EfCarDal());
            var carList = carManager.GetAll();
            if (!carList.Data.Any())
            {
                AracEkle();
                carList = carManager.GetAll();
            }


            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental1 = new Rental
            {
                CarId = carList.Data.First().Id,
                CustomerId = customerList.Data.First().Id,
                RentDate = DateTime.Now,
            };
            Console.WriteLine(rentalManager.Add(rental1).Message);

            Rental rental2 = new Rental
            {
                CarId = carList.Data.First().Id,
                CustomerId = customerList.Data.First().Id,
                RentDate = new DateTime(2021,4,10)
            };
            Console.WriteLine(rentalManager.Add(rental2).Message);

        }

        private static void AracEkle()
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
            Console.WriteLine(carManager.Add(car1).Message);


            Car car2 = new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 325500,
                Description = "Sahibinden Temiz Araç",
                ModelYear = 2019
            };
            Console.WriteLine(carManager.Add(car2));

            Car car3 = new Car
            {
                BrandId = 3,
                ColorId = 2,
                DailyPrice = 65500,
                Description = "Hata Kaza Değişen Yok! Sadece 2 parça boyalı geyik çarptı :)",
                ModelYear = 2009
            };
            Console.WriteLine(carManager.Add(car3).Message);

            //update
            car1.ModelYear = 2015;
            carManager.Update(car1);

            //Delete
            carManager.Delete(car2);

            //List Cars
            var result = carManager.GetCarDetailDtos();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine($"Car Name : {item.CarName}, Brand Name : {item.BrandName}, Color Name : {item.ColorName}, Daily Price : {item.DailyPrice.ToString("n2")}");
                }
            }
        }
    }
}
