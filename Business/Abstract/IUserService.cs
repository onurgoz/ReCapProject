using Core.Business;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        IDataResult<User> GetById(int id);
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        User GetByMail(string email);
    }
}
