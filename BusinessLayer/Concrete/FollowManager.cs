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
    public class FollowManager : IFollowService
    {
        IFollowDAL _dal;
        public FollowManager(IFollowDAL dal)
        {
            _dal = dal;
        }
        public void Add(Follow entity)
        {
            _dal.Add(entity);
            _dal.Save();
        }

        public void Delete(Expression<Func<Follow, bool>> obj)
        {
            _dal.Delete(obj);
            _dal.Save();
        }

        public Follow GetByFilter(Expression<Func<Follow, bool>> obj)
        {
           return _dal.GetByFilter(obj);
        }

        public List<Follow> GetList(Expression<Func<Follow, bool>> obj = null)
        {
            return _dal.GetList(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Follow category)
        {
            _dal.Update(category);
            _dal.Save();
        }
    }
}
