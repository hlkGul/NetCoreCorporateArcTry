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
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        //add metodumuzda validation yok ama aspect ekleyerek bu islemi sagladık. AOP !!
        [ValidationAspect(typeof(ProductValidator))]
        //AOP mimarisiyle business icinde business yazacagiz attiribute lar ile yapilir. Spring default saglar
        [SecuredOperation("product.add")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIsProductNameExists(product.ProductName),
                CheckIfCategoryLimitExceded());

               

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);



            //business kodu ve validation kodları ayrı yapılmalıdır!!!
            //iş kurallarına dahil edilip edilemeyecegini belirlemek icin validation gereklidir.


            //ValidationTool.Validate(new ProductValidator(), product);

            //IResulttan gelen result ı return ediyoruz.
            //Messages lar sabit olarak iş katmanından gelecek

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
        [ValidationAspect(typeof(ProductValidator))]

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new Result(true,Messages.ProductAdded);
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIsProductNameExists(string productName)
        {
            if (_productDal.GetAll(p => p.ProductName == productName).Any())
            {
                return new ErrorResult(Messages.ProductNameIsSame);
            }
            return new SuccessResult();
        }
        //tek basına servis olmadıgı icin buraya yazıldı categoryManager yerine productın category servisi yorumlama sekli
        private IResult CheckIfCategoryLimitExceded()
        {
            //_categoryService geldiginde bize categoryManager cagıracak. AutoFac ile dependency resolver kısmında cozulecek
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryCountBounded);

            }
            return new SuccessResult();
        }
    }
}
