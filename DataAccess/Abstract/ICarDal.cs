﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);

        List<Car> GetById(Car car);

        List<Car> GetAll();
        List<Car> GetByBrand(int brandId);
        List<Car> GetByColor(int colorId);


    }
}
