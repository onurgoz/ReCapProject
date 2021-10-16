using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;

namespace Business.Concrete
{
    [ValidationAspect(typeof(RentalValidator))]
    public class RentalManager : GenericManager<Rental, IRentalDal>, IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal) : base(rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public override IResult Add(Rental entity)
        {
            var result = _rentalDal.GetByLastCarId(entity.CarId);
            if (result.Data.ReturnDate != null)
            {
                return base.Add(entity);
            }
            else
            {
                return new ErrorResult("This car is not suitable.");
            }
        }
        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(I => I.Id == id);
            return new SuccessDataResult<Rental>(result);
        }
    }
}
