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
            CarManager carManager=new CarManager(new EfCarDal());
            foreach (var Car in carManager.GetAll())
            {
                Console.WriteLine(Car.ColorId);
            }
            
            carManager.Add(new Car {BrandId=4,ColorId=4,CarName="CarName2",ModelYear=2004,DailyPrice=2000,Description="Description4" });
        }
    }
}
