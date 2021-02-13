using Bussines.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using DataAccess.Concrete.EntityFramework;
using Business.Concrete;

namespace ConsoleUI
{
    class Program
    {


        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            //GetAllCars(rentACarManager);
            //AddCar(rentACarManager);
            //DeleteCar(rentACarManager);
            //UpdateCar(rentACarManager);
            //GetAllCarsDetail(carManager);
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental() { CarId = 6, CustomerId = 1, RentDate = DateTime.Now };
            rentalManager.Add(rental);

        }

        private static void GetAllCarsDetail(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " : " + car.CarName + " - " + car.ColorName + " Color" + " = " + car.DailyPrice + " Liras For a Day");
            }
        }

        private static void UpdateCar(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                if (car.CarId == 2006)
                {
                    var updatedCar = car;
                    updatedCar.CarName = "Volvo s60";
                    carManager.Update(updatedCar);
                }
            }
        }

        private static void DeleteCar(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                if (car.CarId == 2006)
                {
                    carManager.Delete(car);
                }
            }
        }

        private static void AddCar(CarManager carManager)
        {
            Car car2 = new Car { BrandId = 22, CarName = "Accent-Era", ColorId = 4, DailyPrice = 90, ModelYear = 2010, Description = "Min Money", Rentable = false };
            carManager.Add(car2);
            Console.WriteLine("After Added Database");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName + ": DailyPrice= " + car.DailyPrice);
            }
        }

        private static void GetAllCars(CarManager carManager)
        {
            Console.WriteLine("All Cars List");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName + ": DailyPrice= " + car.DailyPrice);
            }
        }

    }
}
