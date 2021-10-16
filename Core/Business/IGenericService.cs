using Core.Entites.Abstract;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.Business
{
    public interface IGenericService<T> where T : class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);

    }
}
