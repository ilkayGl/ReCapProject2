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

            //CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //UserManager userManager = new UserManager(new EfUserDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //CarTest();

        }

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    var result = carManager.GetCarDetails();
        //    if (result.Success == true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine("Ürün Id : " + car.Id + " ---- " + "Araç Açıklaması : " + car.Descriptions);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }




    }
}
