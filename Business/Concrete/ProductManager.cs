using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        ISubCategoryService _subCategoryService;
        public ProductManager(IProductDal productDal, ISubCategoryService subCategoryService)
        {
            _productDal = productDal;
            _subCategoryService = subCategoryService;
        }

        [SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            product.AddedDate = DateTime.Now;
            product.Id = Guid.NewGuid();            
            
            IResult result = BusinessRules.Run(
                CheckIfProductCountOfSubCategoryCorrect(product.SubCategoryId),
                CheckIfProductNameExists(product.ProductName),
                CheckIfSubCategoryLimitExceded()
                );

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);


        }

        //[CacheAspect] // key,value
        public IDataResult<List<Product>> GetAll()
        {
            
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllBySubCategoryId(Guid id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(item => item.SubCategoryId == id));
        }

        [SecuredOperation("product.add,Admin")]
        public IDataResult<List<Product>> GetAllByCategoryId(Guid id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(item => item.SubCategory.CategoryId == id));
        }
        public IDataResult<List<Product>> GetAllByPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(item => item.SalePrice >= min && item.SalePrice <= max));
        }
        //[CacheAspect]
        public IDataResult<Product> GetById(Guid id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(item => item.Id == id));
        }
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        //[ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IResult Delete(Product product)
        {
            product.IsDeleted = true;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfSubCategoryCorrect(Guid subCategoryId)
        {
            var count = _productDal.GetAll(item => item.SubCategoryId == subCategoryId).Count;
            if (count >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfSubCategoryError);

            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(item => item.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            }
            return new SuccessResult();
        }

        private IResult CheckIfSubCategoryLimitExceded()
        {
            var result = _subCategoryService.GetAll().Data.Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);

            }
            return new SuccessResult();
        }       

        public IDataResult<List<Product>> GetAllProductsWithImages()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAllProductsWithImages());
        }
    }
}
