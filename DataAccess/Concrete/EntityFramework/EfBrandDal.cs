using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarDbContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from ca in context.Brands
                             join co in context.Colors
                             on ca.BrandId equals co.ColorId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             select new BrandDetailDto
                             {
                                 BrandId=co.ColorId,
                                 ColorId = co.ColorId,
                                 BrandName = ca.BrandName,
                                 ColorName = co.ColorName,

                             };

                return result.ToList();
            }
        }
    }
}
