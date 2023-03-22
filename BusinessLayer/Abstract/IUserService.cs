using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        void Delete(Expression<Func<User, bool>> obj);
        void Add(User user);
        void Update(User user);
        List<User> GetList(Expression<Func<User, bool>> obj = null);
        User GetByFilter(Expression<Func<User, bool>> obj);
        void Save();
      
    }
}
