using Business.Abstract;
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
            //CarTested();
            //ColorTested();
            //BrandTested();

        }
        private static void CarTested()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ListedCar(carManager);
            Car car1 = new Car { BrandId = 4, ColorId = 4, CarName = "CarName2", ModelYear = 2004, DailyPrice = 2000, Description = "Description4" };

            carManager.Add(car1);
            ListedCar(carManager);
            car1.BrandId = 1;
            car1.CarName = "Updatedtest";
            carManager.Update(car1);

            var wreadCar = carManager.GetById(car1.Id).Data;
            Console.WriteLine(wreadCar.Id + " -- " + wreadCar.CarName + " -- " + wreadCar.BrandId + " -- " + wreadCar.ColorId + " -- " + wreadCar.ModelYear + " -- " + wreadCar.DailyPrice + " -- " + wreadCar.Description);
            carManager.Delete(car1);
            ListedCar(carManager);
            ListedCarDetails(carManager);
        }

        private static void BrandTested()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ListedBrand(brandManager);
            Brand brand1 = new Brand { Name = "Aston Martin" };

            brandManager.Add(brand1);
            ListedBrand(brandManager);
            brand1.Name = "Martin";
            brandManager.Update(brand1);
            brandManager.GetById(brand1.Id);
            ListedBrand(brandManager);
            brandManager.Delete(brand1);
            ListedBrand(brandManager);
        }

        private static void ColorTested()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ListedColor(colorManager);
            Color brand1 = new Color { Name = "Ocean blue" };

            colorManager.Add(brand1);
            ListedColor(colorManager);
            brand1.Name = "Slate Blue";
            colorManager.Update(brand1);
            colorManager.GetById(brand1.Id);
            ListedColor(colorManager);
            colorManager.Delete(brand1);
            ListedColor(colorManager);
        }
        //ToDo: Listed Metod Fixed next version...
        private static void ListedColor(ColorManager colorManager)
        {
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + " -- " + color.Name);
            }
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
        }
        private static void ListedBrand(BrandManager brandManager)
        {
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + " -- " + brand.Name);
            }
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
        }
        private static void ListedCar(CarManager carManager)
        {
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
            Console.WriteLine("ID -- Car Name -- Brand -- Color -- Model -- Daily Price -- Description");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + " -- " + car.CarName + " -- " + car.BrandId + " -- " + car.ColorId + " -- " + car.ModelYear + " -- " + car.DailyPrice + " -- " + car.Description);
            }
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
        }
        private static void ListedCarDetails(CarManager carManager)
        {
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
            Console.WriteLine("ID -- Car Name -- Brand -- Color -- Model -- Daily Price -- Description");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " -- " + car.BrandName + " -- " + car.ColorName + " -- " + car.ModelYear + " -- " + car.DailyPrice + " -- " + car.Description);
            }
            Console.WriteLine("\n \n \n \n************************************* \n\n\n");
        }


    }
}
