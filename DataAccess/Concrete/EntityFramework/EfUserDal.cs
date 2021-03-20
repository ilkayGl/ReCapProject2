using Core.DataAccsess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarDbContext>, IUserDal
    {
        public List<CustomerRentalDetailDto> GetCustomerAndRentalDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Customers
                             join r in context.Rentals
                                 on c.CustomerId equals r.CustomerId
                             join u in context.Users
                                 on c.CustomerId equals u.UserId
                             select new CustomerRentalDetailDto()
                             {
                                 RentalId = r.RentalId,
                                 UserId = u.UserId,
                                 CustomerId = c.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();

            }
        }

        public bool DeleteUserIfNotReturnDateNull(User user)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var find = GetCustomerAndRentalDetails().Any(i => i.UserId == user.UserId && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(user);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = userOperationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }

        }
    }
}
