using Core.DataAccsess;
using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDbContext>, IEntityRepository<Rental>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join cstmr in context.Customers
                             on r.CustomerId equals cstmr.CustomerId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CustomerId = cstmr.CustomerId,
                                 CarName = b.BrandName,
                                 ColorName = color.ColorName,
                                 CustomerInfo = $"{cstmr.FirstName} {cstmr.LastName}",
                                 CompanyName = cstmr.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();

            }
        }


        public bool DeleteRentalIfNotReturnDateNull(Rental rental)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var find = context.Rentals.Any(i => i.RentalId == rental.RentalId && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(rental);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }

        }

    }
}
