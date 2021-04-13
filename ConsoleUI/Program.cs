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
            //CarTest();
            //BrandTest();
            //ColorTest();
            //CustomerTest();
            //UserTest();
            RentalTest();
        }
        static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental {
            RentalId=2,
            CustomerId=1,
            CarId=2,
            RentDate= DateTime.Now
            });
            Console.WriteLine(result.Message);
            //var result = rentalManager.GetAll();
            //if (result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine(item.RentalId);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }
        static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //var result= customerManager.Add(new Customer()
            //{
            //    CustomerId = 1,
            //    UserId = 1,
            //    CompanyName = "Deneme 3 Şirketi"
            //});
            //Console.WriteLine(result.Message);
            var result = customerManager.GetAll();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
           
            var result = userManager.GetAll();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.FirstName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand
            //{
            //    BrandId = 5,
            //    BrandName= "Hyundai"
            //});

            var result = brandManager.GetAll();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
         static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
 
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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

            //carManager.Add(new Car()
            //{
            //    CarId = 6,
            //    BrandId = 2,
            //    ColorId = 4,
            //    DailyPrice = 150,
            //    Description = "Deneme",
            //    ModelYear = "2011"
            //});
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description+"/"+car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
