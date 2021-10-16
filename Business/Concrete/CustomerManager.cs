using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    [ValidationAspect(typeof(CustomerValidator))]
    public class CustomerManager : GenericManager<Customer, ICustomerDal>, ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal) : base(customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetUsurId(int id)
        {
            var result = _customerDal.GetAll(I => I.UserId == id).ToList();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(I => I.Id == id);
            return new SuccessDataResult<Customer>(result);
        }
    }
}
