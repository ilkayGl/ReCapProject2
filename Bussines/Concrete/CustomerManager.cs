using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Bussines.Constants;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        //[CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }



        [CacheAspect]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }



        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }




        //[CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            var result = _customerDal.DeleteCustomerIfNotReturnDateNull(customer);
            if (result)
            {
                return new SuccessResult(Messages.CustomerDelete);
            }

            return new ErrorResult(Messages.NotDeleted);

        }


        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdate);
        }
    }
}
