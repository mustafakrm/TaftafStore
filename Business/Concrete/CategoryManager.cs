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
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            category.Id=Guid.NewGuid();
            _categoryDal.Add(category);

            return new SuccessResult(Messages.CategoryAdded);

        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(Guid categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(item=>item.Id==categoryId));
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);

        }
        public IResult Delete(Category category)
        {
            category.IsDeleted = true;
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryDeleted);

        }


    }
}
