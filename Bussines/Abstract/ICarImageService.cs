using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetById(int Id);
        IDataResult<List<CarImage>> GetCarsByCarId(int carId);
        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
    }
}
