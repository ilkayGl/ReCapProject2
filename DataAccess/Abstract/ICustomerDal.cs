﻿using Core.DataAccsess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        //List<CustomerDetailDto> GetCustomerDetails();
        bool DeleteCustomerIfNotReturnDateNull(Customer customer);
    }
}
