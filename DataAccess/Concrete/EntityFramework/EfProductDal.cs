using Core.Dal.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, TaftafStoreDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (TaftafStoreDbContext context = new TaftafStoreDbContext())
            {
                var result = from p in context.Products
                             join c in context.SubCategories
                             on p.SubCategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                 SubCategoryName = c.SubCategoryName,
                                 UnitsInStock = p.UnitsInstock
                             };
                return result.ToList();
            }
        }        
        public List<Product> GetAllProductsWithImages()
        {
            using (TaftafStoreDbContext context=new TaftafStoreDbContext())
            {
                var result = from p in context.Products.Include(p => p.Images)
                             select new Product
                             {
                                 Id = p.Id,
                                 ProductName = p.ProductName,
                                 SalePrice = p.SalePrice,
                                 PurchasePrice = p.PurchasePrice,
                                 DiscountPrice = p.DiscountPrice,
                                 AddedDate = p.AddedDate,
                                 UnitsInstock = p.UnitsInstock,
                                 SubCategory = p.SubCategory,
                                 Images = p.Images.ToList(),
                                 Description = p.Description,
                                 IsDeleted = p.IsDeleted,
                             };
                return result.ToList();
            }
        }
    }
}
