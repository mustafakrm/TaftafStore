using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(Guid imageId)
        {
            var result = _imageService.GetById(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByproductId")]
        public IActionResult GetByproductId(Guid productId)
        {
            var result = _imageService.GetAllByProductId(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Image image)
        {

            var result = _imageService.Add(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Image image)
        {

            var result = _imageService.Update(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Image image)
        {

            var result = _imageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
