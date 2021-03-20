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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId
                             join co in context.Colors
                                 on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 BrandModel = b.BrandModel,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList()
                             };
                return result.ToList();
            }
        }



        public bool DeleteCarIfNotReturnDateNull(Car car)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var find = context.Rentals.Any(i => i.CarId == car.CarId && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(car);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

    }
}
