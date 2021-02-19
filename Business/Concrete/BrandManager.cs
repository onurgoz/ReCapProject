using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Brand added.\n   " + brand.Name);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Brand deleted.\n   " + brand.Name);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(c => c.Id == brandId);
        }

        public void update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Brand updated.\n   " + brand.Name);
        }
    }
}
