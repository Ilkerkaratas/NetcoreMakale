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
    //UI katmanımd yorum ile ilgili veri tabanı işlemleri yapabilmem için tasarlanmış manager sınııfı
    //Generic repositoryde tanımlanan bütün işleri yapr tek farkı kayıt işlemi ayrı bir method olarak kullanmadım burda.
    public class YorumManager : IYorumService
    {
        IYorumDAL dAL;
        public YorumManager(IYorumDAL dALP)
        {
            dAL = dALP;
        }
        public void Add(Yorum entity)
        {
            dAL.Add(entity);
            dAL.Save();
        }

        public void Delete(Expression<Func<Yorum, bool>> obj)
        {
            dAL.Delete(obj);
            dAL.Save();
        }

        public Yorum GetByFilter(Expression<Func<Yorum, bool>> obj)
        {
           return dAL.GetByFilter(obj);
        }

        public List<Yorum> GetList(Expression<Func<Yorum, bool>> obj = null)
        {
            return dAL.GetList(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Yorum yorum )
        {
            dAL.Update(yorum);
            dAL.Save();
        }
    }
}
