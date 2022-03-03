using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        public IResult Add(Image image)
        {
            image.Id = Guid.NewGuid();
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(Image image)
        {
            image.IsDeleted = true;
            _imageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetAllByProductId(Guid productId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(item => item.ProductId == productId));
        }

        public IDataResult<Image> GetById(Guid imageId)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(item => item.Id == imageId));
        }

        public IResult Update(Image image)
        {
            _imageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }
    }
}
