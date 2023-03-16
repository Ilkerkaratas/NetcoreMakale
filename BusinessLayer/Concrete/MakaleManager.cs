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
    //UI katmanımd makale ile ilgili veri tabanı işlemleri yapabilmem için tasarlanmış manager sınııfı
    //Generic repositoryde tanımlanan bütün işleri yapr tek farkı kayıt işlemi ayrı bir method olarak kullanmadım burda.
    public class MakaleManager : IMakaleService
    {
        IMakaleDAL makaleDAL;
        public MakaleManager(IMakaleDAL makale) 
        {
            makaleDAL = makale;
        }
        public void Add(Makale entity)
        {
            makaleDAL.Add(entity);
            makaleDAL.Save();
        }
        public void Update(Makale entity)
        {
            makaleDAL.Update(entity);
            makaleDAL.Save();
        }

        public void Delete(Expression<Func<Makale, bool>> obj)
        {
            makaleDAL.Delete(obj);
            makaleDAL.Save();
        }

        public Makale GetByFilter(Expression<Func<Makale, bool>> obj)
        {
           return makaleDAL.GetByFilter(obj);
        }

        public List<Makale> GetList(Expression<Func<Makale, bool>> obj = null)
        {
            return makaleDAL.GetList(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

     
    }
}
