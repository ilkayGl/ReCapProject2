using Core.DataAccsess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        List<CarColorDetailDto> GetCarColorDetails();
        bool DeleteColorIfNotReturnDateNull(Color color);
    }
}
