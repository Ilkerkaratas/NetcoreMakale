using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL userDAL;
        public UserManager(IUserDAL dAL) 
        {
            userDAL = dAL;
        }
        public void Add(User user)
        {
            userDAL.Add(user);
            userDAL.Save();
        }
        public void Update(User user)
        {
            userDAL.Update(user);
            userDAL.Save();
        }

        public void Delete(Expression<Func<User, bool>> obj)
        {
            userDAL.Delete(obj);
            userDAL.Save();
        }

        public User GetByFilter(Expression<Func<User, bool>> obj)
        {
            return userDAL.GetByFilter(obj);
        }

        public List<User> GetList(Expression<Func<User, bool>> obj = null)
        {
            return userDAL.GetList(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Varmi(string ad, string Sifre)
        {
            return userDAL.Varmi(ad,Sifre);
        }
    }
}
