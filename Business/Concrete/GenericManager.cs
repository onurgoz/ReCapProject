using Core.Aspects.Caching;
using Core.Business;
using Core.DataAccess;
using Core.Entites.Abstract;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{

    public class GenericManager<T, TDal> : IGenericService<T> where T : class, IEntity, new() where TDal : IEntityRepository<T>
    {
        TDal _dal;

        public GenericManager(TDal dal)
        {
            _dal = dal;
        }

        public virtual IResult Add(T entity)
        {
            _dal.Add(entity);
            return new SuccessDataResult<T>(entity);
        }

        public virtual IResult Delete(T entity)
        {
            _dal.Delete(entity);
            return new SuccessDataResult<T>(entity);
        }
        [CacheAspect]
        public virtual IDataResult<List<T>> GetAll()
        {
            var result = _dal.GetAll().ToList();
            return new SuccessDataResult<List<T>>(result);
        }

        public virtual IResult Update(T entity)
        {
            _dal.Update(entity);
            return new SuccessDataResult<T>(entity);
        }
    }
}
