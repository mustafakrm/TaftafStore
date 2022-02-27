using Core.Dal.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSubCategoryDal : EfEntityRepositoryBase<SubCategory, TaftafStoreDbContext>, ISubCategoryDal
    {

    }
}
