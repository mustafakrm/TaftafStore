using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllBySubCategoryId(Guid id);
        IDataResult<List<Product>> GetAllByCategoryId(Guid id);
        IDataResult<List<Product>> GetAllByPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(Guid id);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);


        IResult AddTransactionalTest(Product product);
    }
}
