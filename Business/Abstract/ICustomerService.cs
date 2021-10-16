using Core.Business;
using Core.Utilities.Results;
using Entites.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetUsurId(int id);
    }
}
