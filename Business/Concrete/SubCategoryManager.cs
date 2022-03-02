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
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public IResult Add(SubCategory subCategory)
        {
            subCategory.Id = Guid.NewGuid();
            _subCategoryDal.Add(subCategory);

            return new SuccessResult(Messages.SubCategoryAdded);
        }

        public IResult Delete(SubCategory subCategory)
        {
            subCategory.IsDeleted = true;
            _subCategoryDal.Update(subCategory);
            return new SuccessResult(Messages.SubCategoryDeleted);
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll());
        }

        public IDataResult<SubCategory> GetById(Guid subCategoryId)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(item => item.Id == subCategoryId));
        }

        public IResult Update(SubCategory subCategory)
        {
            _subCategoryDal.Update(subCategory);
            return new SuccessResult(Messages.SubCategoryUpdated);
        }
    }
}
