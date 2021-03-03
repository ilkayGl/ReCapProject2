using Core.DataAccsess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //List<CarDetailDto> GetCarDetails(Expression<Func<User, bool>> filter = null);
        List<OperationClaim> GetClaims(User user);
    }
}
