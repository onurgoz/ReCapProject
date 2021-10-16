using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;

namespace Business.Concrete
{
    [ValidationAspect(typeof(ColorValidator))]
    public class ColorManager : GenericManager<Color, IColorDal>, IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal) : base(colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(I => I.Id == id);
            return new SuccessDataResult<Color>(result);
        }
    }
}
