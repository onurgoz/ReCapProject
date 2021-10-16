using Core.Business;
using Core.Utilities.Results;
using Entites.Concrete;

namespace Business.Abstract
{
    public interface IRentalService : IGenericService<Rental>
    {
        IDataResult<Rental> GetById(int id);
    }
}
