using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        bool DeleteCarIfNotReturnDateNull(Car car);
    }
}
