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
    public class Categorymanager : ICategoryService
    {
       //UI katmanımd categori ile ilgili veri tabanı işlemleri yapabilmem için tasarlanmış manager sınııfı
       //Generic repositoryde tanımlanan bütün işleri yapr tek farkı kayıt işlemi ayrı bir method olarak kullanmadım burda.
        ICategoryDAL categoryDAL;
        public Categorymanager(ICategoryDAL dAL)
        {
            categoryDAL = dAL;
        }
    public void Add(Category entity)
    {
        categoryDAL.Add(entity);
        categoryDAL.Save();

    }
        public void Update(Category entity)
        {
            categoryDAL.Update(entity);
            categoryDAL.Save();

        }

        public void Delete(Expression<Func<Category, bool>> obj)
    {
        categoryDAL.Delete(obj);
        categoryDAL.Save();
    }

    public Category GetByFilter(Expression<Func<Category, bool>> obj)
    {
        return categoryDAL.GetByFilter(obj);
    }

    public List<Category> GetList(Expression<Func<Category, bool>> obj = null)
    {
        if (obj == null)
        {
            return categoryDAL.GetList();
        }
        else
        {
            return categoryDAL.GetList(obj);

        }
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
}
