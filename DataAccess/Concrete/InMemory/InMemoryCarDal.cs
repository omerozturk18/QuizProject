using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{CarId = 1 ,BrandId = 1 , ColorId = 5 ,DailyPrice = 500, Description = "Suv" ,ModelYear = "2016" },
                new Car{CarId = 2 ,BrandId = 1 , ColorId = 3 ,DailyPrice = 600, Description = "Sedan" ,ModelYear = "2019" },
                new Car{CarId = 3 ,BrandId = 1 , ColorId = 9 ,DailyPrice = 1100, Description = "Sport" ,ModelYear = "2021" },
                new Car{CarId = 4 ,BrandId = 1 , ColorId = 7 ,DailyPrice = 900, Description = "Jip" ,ModelYear = "2013" },
                new Car{CarId = 3 ,BrandId = 1 , ColorId = 6 ,DailyPrice = 1000, Description = "classic" ,ModelYear = "1965" },
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
            Console.WriteLine("Araba Eklendi");
        }

        public void Delete(Car car)
        {
            Car carToDelete =_car.SingleOrDefault(c=>c.CarId==car.CarId);
            _car.Remove(carToDelete);
            Console.WriteLine("Araba Silindi");
        }
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate = car;
            Console.WriteLine("Araba Güncellendi");
        }

        public List<Car> GetById(Car car)
        {
           return _car.Where(c => c.CarId == car.CarId).ToList();
        }
        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetByBrand(int brandId)
        {
           return _car.Where(c => c.BrandId ==brandId).ToList();
        }

        public List<Car> GetByColor(int colorId)
        {
            return _car.Where(c => c.ColorId == colorId).ToList();
        }
    }
}
