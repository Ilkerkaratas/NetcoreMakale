using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILikeService
    {
        void Delete(Expression<Func<Like, bool>> obj);
        void Update(Like entity);
        void Add(Like entity);
        List<Like> GetList(Expression<Func<Like, bool>> obj = null);
        Like GetByFilter(Expression<Func<Like, bool>> obj);
        void Save();

    }
}
