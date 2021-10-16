using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarTested();
            //EfCustomerTest();
            //EfCarTested();
            EfRentalTest();
        }

        private static void EfRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            int carId, customerId;
            DateTime rentDate, returnDate;
            
            
            carId=Convert.ToInt32(Console.ReadLine());
            customerId=Convert.ToInt32(Console.ReadLine());
            rentDate = Convert.ToDateTime(Console.ReadLine());
            returnDate = Convert.ToDateTime(Console.ReadLine());
            Rental rental = new Rental {CarId=carId,CustomerId=customerId,RentDate=rentDate,ReturnDate=returnDate };
            rentalManager.Add(rental);
            Console.WriteLine("ID    CarID   CustomerID    RentDate    ReturnDate");
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + "  " + item.CarId+"   "+ item.CustomerId + "  " +item.RentDate+""+item.ReturnDate );
            }
        }

        private static void EfCustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());


            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + "  " + item.UserId + "  " + item.CompanyName);
            }
        }

        static void EfCarTested()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            GetAllFunc(carManager);
            //GetByBrandIdFunc(carManager,3);
            GetByColorIdFunc(carManager, 1);
            GetCarDetailFunc(carManager);
        }

        static void InMemoryCarTested()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            GetAllFunc(carManager);
            var car2 = carManager.GetById(2);
            carManager.Delete(car2.Data);
            GetAllFunc(carManager);

        }

        static void GetAllFunc(CarManager carManager)
        {
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
            }
            Console.WriteLine("**********************/n");
        }

        static void GetCarDetailFunc(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId, item.BrandName, item.ColorName, item.ModelYear, item.DailyPrice, item.Description);
                }
            }

            Console.WriteLine("**********************/n");
        }

        static void GetByBrandIdFunc(CarManager carManager, int id)
        {
            foreach (var item in carManager.GetCarsByBrandId(id).Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
            }
            Console.WriteLine("**********************/n");
        }

        static void GetByColorIdFunc(CarManager carManager, int id)
        {
            var result = carManager.GetCarsByColorId(id);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
                }
            }

            Console.WriteLine("**********************/n");
        }
    }
}
