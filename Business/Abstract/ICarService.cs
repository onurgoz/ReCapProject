using Core.Business;
using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : IGenericService<Car>
    {
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();

        IResult AddTransactionalTest(Car car);
    }
}
