using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //AOP mimarisiyle business icinde business yazacagiz attiribute lar ile yapilir. Spring default saglar
        public IResult Add(Product product)
        {
            //business kodu ve validation kodları ayrı yapılmalıdır!!!
            //iş kurallarına dahil edilip edilemeyecegini belirlemek icin validation gereklidir.


            ValidationTool.Validate(new ProductValidator(), product);

            _productDal.Add(product);
            //IResulttan gelen result ı return ediyoruz.
            //Messages lar sabit olarak iş katmanından gelecek
            return new Result(true, Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 17)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }
        //sonrasında bilgilendirme icin ekstra bir yapı olusturulacak orn: basarili vs.
        public IDataResult<Product> GetById(int productId)
        {
            //istek yapılan id icin eslesen product donecek
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }


    }
}
