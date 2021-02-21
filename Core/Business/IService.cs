using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IService<T>
        where T: class, IEntity,new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int entityId);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
