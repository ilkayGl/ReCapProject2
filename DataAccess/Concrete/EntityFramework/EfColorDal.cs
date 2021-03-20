using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarDbContext>, IColorDal
    {
        public List<CarColorDetailDto> GetCarColorDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                                 on c.ColorId equals co.ColorId
                             join r in context.Rentals
                                 on c.CarId equals r.CarId
                             select new CarColorDetailDto()
                             {
                                 ColorId = co.ColorId,
                                 CarId = c.CarId,
                                 RentalId = r.RentalId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }

        public bool DeleteColorIfNotReturnDateNull(Color color)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var find = GetCarColorDetails().Any(i => i.ColorId == color.ColorId && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(color);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
