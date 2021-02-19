using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    Console.WriteLine(car.CarName + " added.");
                }
                else
                {
                    Console.WriteLine("Please enter the daily price value greater than 0. \n Daily price : " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine("please enter the car name value greater than 2 characters. \n Car name : " + car.CarName);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Id + " was deleted.");
            
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.Id+" was updated.");
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
