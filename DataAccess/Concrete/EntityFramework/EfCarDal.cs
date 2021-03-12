using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 CarName = ca.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = ca.DailyPrice,
                                 Description=ca.Description,
                                 ModelYear=ca.ModelYear
                             };

                return result.ToList();
            }
        }


    }
}
