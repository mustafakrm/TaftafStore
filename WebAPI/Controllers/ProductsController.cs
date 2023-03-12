using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            //Thread.Sleep(1000);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getAllProductsWithImages")]
        public IActionResult GetAllProductsWithImages()
        {

            var result = _productService.GetAllProductsWithImages();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("GetProductDetails")]
        public IActionResult GetProductDetails()
        {
            
            var result = _productService.GetProductDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(Guid productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpGet("getBySubCategoryId")]
        public IActionResult GetBySubCategoryId(Guid subCategoryId)
        {
            var result = _productService.GetAllBySubCategoryId(subCategoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByCategoryId")]
        public IActionResult GetByCategoryId(Guid categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {

            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {

            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {

            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
