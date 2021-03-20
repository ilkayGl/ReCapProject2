using Business.Abstract;
using Bussines.Constants;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }



        [CacheAspect]
        public IDataResult<List<Rental>> GetRentalByUndelivered()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null), Messages.RentalListed);
        }



        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }



        [CacheAspect]
        public IDataResult<Rental> GetById(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId), Messages.RentalListed);
        }




        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator), Priority = 1)]
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.NotAvailable);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }



        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.DeleteRentalIfNotReturnDateNull(rental);
            if (result)
            {
                return new SuccessResult(Messages.RentalDelete);
            }

            return new ErrorResult(Messages.NotDeleted);
        }




        [ValidationAspect(typeof(RentalValidator), Priority = 1)]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
