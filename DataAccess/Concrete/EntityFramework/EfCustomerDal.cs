using Core.DataAccsess;
using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarDbContext>, ICustomerDal
    {
        public bool DeleteCustomerIfNotReturnDateNull(Customer customer)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var find = context.Rentals.Any(i => i.CustomerId == customer.CustomerId && i.ReturnDate == null);
                if (!find)
                {
                    context.Remove(customer);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
