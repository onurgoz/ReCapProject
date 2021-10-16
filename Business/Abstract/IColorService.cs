using Core.Business;
using Core.Utilities.Results;
using Entites.Concrete;

namespace Business.Abstract
{
    public interface IColorService : IGenericService<Color>
    {
        IDataResult<Color> GetById(int id);
    }
}
