
using Core.DataAccess;
using DataAccess.Abstract;
using Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DatabaseContext>, ICustomerDal
    {
    }
}
