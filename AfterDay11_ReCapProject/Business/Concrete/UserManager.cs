using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
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
            _userDal=userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.SaveSuccessful);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeleteSuccessful);
        }

        public IDataResult<List<User>> GetAll()
        {
            if(_userDal.GetAll().Count==0)
            {
                return new ErrorDataResult<List<User>>(_userDal.GetAll(),Messages.ListedFailed);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.ListedSuccessful);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.GetById(u=>u.Id==id),Messages.ListedSuccessful);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdateSuccessful);
        }
    }
}
