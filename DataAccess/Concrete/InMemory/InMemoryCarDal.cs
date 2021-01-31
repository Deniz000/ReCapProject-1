﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = "2015", DailyPrice = 500, Description = "Car1"},
                new Car{Id = 2, BrandId = 1, ColorId = 2, ModelYear = "2018", DailyPrice = 800, Description = "Car2"},
                new Car{Id = 3, BrandId = 2, ColorId = 3, ModelYear = "2019", DailyPrice = 1000, Description = "Car3"},
                new Car{Id = 4, BrandId = 2, ColorId = 3, ModelYear = "2018", DailyPrice = 900, Description = "Car4"}
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c=>c.BrandId == brandId).ToList();           
        }
    }
}