using Core.DataAccess;
using DataAccess.Abstract;
using Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IEntityRepository<Rental>, IBrandDal
    {
    }
}
