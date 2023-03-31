using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFollowService
    {
        void Delete(Expression<Func<Follow, bool>> obj);
        void Add(Follow entity);
        void Update(Follow category);
        List<Follow> GetList(Expression<Func<Follow, bool>> obj = null);
        Follow GetByFilter(Expression<Func<Follow, bool>> obj);
        void Save();
    }
}
