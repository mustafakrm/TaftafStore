using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {

        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            userOperationClaim.Id=Guid.NewGuid();
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult("User Operation Claim Added");
        }
    }
}
