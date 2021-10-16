using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public IDataResult<Rental> GetByLastCarId(int id)
        {
            using (DatabaseContext context = new())
            {
                var result = from r in context.Rentals
                             where r.CarId == id
                             orderby r.ReturnDate descending
                             select new Rental { CarId = r.CarId, CustomerId = r.CustomerId, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return new SuccessDataResult<Rental>(result.FirstOrDefault());
            }
        }
    }
}
