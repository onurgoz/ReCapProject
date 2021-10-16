using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;

namespace Business.Concrete
{
    [ValidationAspect(typeof(BrandValidator))]
    public class BrandManager : GenericManager<Rental, IBrandDal>, IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) : base(brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _brandDal.Get(I => I.Id == id);
            return new SuccessDataResult<Rental>(result);
        }

    }
}
