using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Bussines.Abstract;
using Bussines.ValidationRules.FluentValidation;
using Bussines.Constants;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Uploads.ImageUploads;
using Core.Aspects.Autofac.Caching;

namespace Bussines.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;
        }



        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(), Messages.ImageListed);
        }



        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            //return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(i => i.CarID == carId), Messages.Listed);

            var result = _imageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, ImageId = 0, Date = DateTime.Now, ImagePath = "/images/car-rent.png" });

            return new SuccessDataResult<List<CarImage>>(images);
        }



        [CacheAspect]
        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(i => i.ImageId == imageId));

        }



        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(
                CheckIfImageCount(carImage),
                CheckIfImageExtensionValid(file));

            if (result != null)
            {
                return result;
            }


            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _imageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);

        }

        public IResult AddCollective(IFormFile[] files, CarImage carImage)
        {
            foreach (var file in files)
            {
                carImage = new CarImage { CarId = carImage.CarId };
                Add(file, carImage);
            }
            return new SuccessResult();
        }



        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(
               CheckIfImageExtensionValid(file));

            if (result != null)
            {
                return result;
            }

            CarImage oldCarImage = GetById(carImage.ImageId).Data;
            carImage.ImagePath = FileHelper.Update(file, oldCarImage.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = oldCarImage.CarId;
            _imageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdate);
        }



        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {

            string oldPath = GetById(carImage.ImageId).Data.ImagePath;
            FileHelper.Delete(oldPath);
            _imageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDelete);
        }

        private IResult CheckIfImageCount(CarImage carImage)
        {
            List<CarImage> gelAll = _imageDal.GetAll(i => i.CarId == carImage.CarId);
            var result = (gelAll.Count() >= 15);
            if (result)
            {
                return new ErrorResult(Messages.ImageLimit); //Bir aracın 5 den fazla resmi olamaz
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            string[] validImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO", ".WEBP" };
            var result = validImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!result)
            {
                return new ErrorResult("Geçersiz uzantı");
            }
            return new SuccessResult();
        }



    }

}
