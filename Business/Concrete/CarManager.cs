using System;
using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System.Collections.Generic;
using Core.Aspects.Transaction;

namespace Business.Concrete
{
    [SecuredOperation("car,admin")]
    [ValidationAspect(typeof(CarValidator))]
    public class CarManager : GenericManager<Car, ICarDal>, ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal) : base(carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");

            }

            Add(car);
            return null;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var car = new Car();
            var result = _carDal.GetAll(I => I.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(result);
        }
        [SecuredOperation("car.add")]
        [CacheRemoveAspect("ICarService.Get")]
        public override IResult Add(Car entity)
        {
            return base.Add(entity);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public override IResult Update(Car entity)
        {
            return base.Update(entity);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public override IResult Delete(Car entity)
        {
            return base.Delete(entity);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(I => I.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(result);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(I => I.Id == id);
            return new SuccessDataResult<Car>(result);
        }
    }
}
