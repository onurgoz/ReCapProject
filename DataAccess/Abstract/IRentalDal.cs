using Core.DataAccess;
using Core.Utilities.Results;
using Entites.Concrete;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        public IDataResult<Rental> GetByLastCarId(int id);
    }
}
