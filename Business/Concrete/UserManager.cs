using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{

    [ValidationAspect(typeof(UserValidator))]
    public class UserManager : GenericManager<User, IUserDal>, IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(I => I.Id == id);
            return new SuccessDataResult<User>(result);
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
