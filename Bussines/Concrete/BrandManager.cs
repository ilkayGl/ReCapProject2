using Business.BusinessAspects.Autofac;
using Bussines.Abstract;
using Bussines.Constants;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);

        }


        [CacheAspect]
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId), Messages.BrandListed);
        }



        [ValidationAspect(typeof(BrandValidator), Priority = 1)]
        [SecuredOperation("admin, product.add")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }



        [ValidationAspect(typeof(BrandValidator), Priority = 1)]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }




        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            var result = _brandDal.DeleteBrandIfNotReturnDateNull(brand);
            if (result)
            {
                return new SuccessResult(Messages.BrandDelete);
            }
            return new ErrorResult(Messages.NotDeleted);
        }
    }
}
