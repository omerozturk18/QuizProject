using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context= new ReCapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.BrandId
                             join c in context.Colors on car.ColorId equals c.ColorId
                             join cI in context.CarImages on car.CarId equals cI.CarId into gr
                             from cI in gr.DefaultIfEmpty()
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 CarImage = cI
                             };
                return result.ToList();
            }
        }
    }
}
