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
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=50000,ModelYear=2005,Description="Açıklama"},
            new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=60000,ModelYear=2006,Description="Açıklama"},
            new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=70000,ModelYear=2007,Description="Açıklama"},
            new Car{Id=4,BrandId=2,ColorId=4,DailyPrice=80000,ModelYear=2008,Description="Açıklama"},
            new Car{Id=5,BrandId=2,ColorId=5,DailyPrice=90000,ModelYear=2009,Description="Açıklama"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Car number " + car.Id + " was added.");
        }

        public void Delete(Car car)
        {
            var CartoDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(CartoDelete);
            Console.WriteLine("Car number "+CartoDelete.Id+" was deleted.");
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            var CartoUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            CartoUpdate.BrandId = car.BrandId;
            CartoUpdate.ColorId = car.ColorId;
            CartoUpdate.DailyPrice = car.DailyPrice;
            CartoUpdate.Description = car.Description;
            CartoUpdate.ModelYear = car.ModelYear;
            Console.WriteLine("Car number " + CartoUpdate.Id + " was updated.");
        }
    }
}
