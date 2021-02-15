using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager=new CarManager(new InMemoryCarDal());
            foreach (var Car in carManager.GetAll())
            {
                Console.WriteLine(Car.ColorId);
            }
        }
    }
}
