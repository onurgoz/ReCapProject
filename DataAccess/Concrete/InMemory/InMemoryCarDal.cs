using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                //new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=50000,ModelYear="2005",Description="Açıklama"},
                //new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=60000,ModelYear="2006",Description="Açıklama"},
                //new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=70000,ModelYear="2007",Description="Açıklama"},
                //new Car{Id=4,BrandId=2,ColorId=4,DailyPrice=80000,ModelYear="2008",Description="Açıklama"},
                //new Car{Id=5,BrandId=2,ColorId=5,DailyPrice=90000,ModelYear="2009",Description="Açıklama"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Car number {0} added.", car.Id);
        }

        public void Delete(Car car)
        {
            var deleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteCar);
            Console.WriteLine("Car number {0} deleted.", car.Id);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public Car GetByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.Description = car.Description;
            updateCar.ModelYear = car.ModelYear;
            Console.WriteLine("Car number {0} was updated.", updateCar.Id);
        }
    }
}
