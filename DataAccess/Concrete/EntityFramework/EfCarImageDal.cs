using Core.DataAccess;
using DataAccess.Abstract;
using Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, DatabaseContext>, ICarImageDal
    {
    }
}
