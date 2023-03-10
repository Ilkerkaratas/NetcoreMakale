using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IYorumService
    {
        void Delete(Expression<Func<Yorum, bool>> obj);
        void Update(Yorum yorum);
        void Add(Yorum entity);
        List<Yorum> GetList(Expression<Func<Yorum, bool>> obj = null);
        Yorum GetByFilter(Expression<Func<Yorum, bool>> obj);
        void Save();
    }
}
