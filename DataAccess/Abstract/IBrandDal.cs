﻿using Core.DataAccsess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        List<CarBrandDetailDto> GetCarAndBrandDetails();
        bool DeleteBrandIfNotReturnDateNull(Brand brand);
    }
}
