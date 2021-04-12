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
            CarTest();
            //  BrandTest();
            //ColorTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId+"-"+brand.BrandName);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId+"-"+color.ColorName);
            }
        }

        static void CarTest()
        {
            // CarManager carManager = new CarManager(new InMemoryCarDal());
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetByBrandId(2))
            //{
            //    Console.WriteLine(car.Description + " BrandId: " + car.BrandId);
            //}

            //foreach (var car in carManager.GetByColorId(1))
            //{
            //    Console.WriteLine(car.Description + " ColorId: " + car.ColorId);
            //}

            //foreach(var car in carManager.GetByDailyPrice(2, 400))
            //{
            //    Console.WriteLine(car.Description + " DailyPrice: " + car.DailyPrice);
            //}

            //carManager.AddCar(new Car()
            //{
            //    CarId = 5,
            //    BrandId = 2,
            //    ColorId = 4,
            //    DailyPrice = 150,
            //    Description = "Deneme",
            //    ModelYear = "2011"
            //});
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description+"/"+car.BrandName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
