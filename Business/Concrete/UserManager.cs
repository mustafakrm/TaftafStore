﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

       

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult Add(User user)
        {
            user.Id = Guid.NewGuid();
            _userDal.Add(user);
            return new SuccessResult();
        }
    }
}
