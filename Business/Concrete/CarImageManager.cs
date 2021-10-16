using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Business.BussinessAspect.Autofac;

namespace Business.Concrete
{
    [ValidationAspect(typeof(CarImageValidator))]
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;


        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(I => I.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));

            if (result != null)
                return result;


            var imagePathResult = FileUpload.Add(formFile);
            if (!imagePathResult.Success)
                return imagePathResult;

            carImage.ImagePath = imagePathResult.Data;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            
            foreach (var carImage in result)
            {
                if (string.IsNullOrEmpty(carImage.ImagePath))
                {
                    carImage.ImagePath = FileUpload.GetDefaultImagePath();
                }
                else
                {
                 carImage.ImagePath=FileUpload.GetImagePath(carImage.ImagePath);   
                }
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }
        [SecuredOperation("admin,car.getall")]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var resultImagePath = GetCarImagePathIfExistsById(carImage.Id);
            if (!resultImagePath.Success)
                return resultImagePath;

            var deleteOldImageAndUpdate = FileUpload.Update(formFile, resultImagePath.Data);
            if (!deleteOldImageAndUpdate.Success)
                return deleteOldImageAndUpdate;
            carImage.Date=DateTime.Now;
            carImage.ImagePath = deleteOldImageAndUpdate.Data;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = GetCarImagePathIfExistsById(carImage.Id);
            if (!result.Success)
                return result;

            var deleteImageResult = FileUpload.Delete(result.Data);
            if (!deleteImageResult.Success)
                return deleteImageResult;

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<string> GetCarImagePathIfExistsById(int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);

            if (carImage == null)
                return new ErrorDataResult<string>(Messages.CarImageNotFound, Messages.CarImageNotFound);

            return new SuccessDataResult<string>(carImage.ImagePath,Messages.CarImageObtained);
        }
    }
}
