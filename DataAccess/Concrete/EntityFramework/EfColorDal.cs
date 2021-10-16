using Core.DataAccess;
using DataAccess.Abstract;
using Entites.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, DatabaseContext>, IEntityRepository<Color>, IColorDal
    {
    }
}
