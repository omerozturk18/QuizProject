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
           // CarManager carManager = new CarManager(new InMemoryCarDal());
            CarManager carManager = new CarManager(new EfCarDal());

                //foreach(var car in carManager.GetCarsByBrandId(2))
                //{
                //    Console.WriteLine(car.Description + " BrandId: " + car.BrandId);
                //}

                //foreach(var car in carManager.GetCarsByColorId(1))
                //{
                //    Console.WriteLine(car.Description + " ColorId: " + car.ColorId);
                //}

                //foreach(var car in carManager.GetByDailyPrice(2, 400))
                //{
                //    Console.WriteLine(car.Description + " DailyPrice: " + car.DailyPrice);
                //}

                //carManager.AddCar(new Car()
                //{
                //    CarId = 4,
                //    BrandId = 1,
                //    ColorId = 3,
                //    DailyPrice = 200,
                //    Description = "Suv",
                //    ModelYear = "2016"
                //});

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
