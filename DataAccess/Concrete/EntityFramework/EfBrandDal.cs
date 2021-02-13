using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess;
using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarDbContext>, IEntityRepository<Brand>, IBrandDal
    {

    }
}
