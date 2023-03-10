using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMakaleService
    {
        void Delete(Expression<Func<Makale, bool>> obj);
        void Update(Makale makale);
        void Add(Makale entity);
        List<Makale> GetList(Expression<Func<Makale, bool>> obj = null);
        Makale GetByFilter(Expression<Func<Makale, bool>> obj);
        void Save();
    }
}
