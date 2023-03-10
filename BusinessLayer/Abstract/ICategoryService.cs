using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void Delete(Expression<Func<Category, bool>> obj);
        void Add(Category entity);
        void Update(Category category);
        List<Category> GetList(Expression<Func<Category, bool>> obj = null);
        Category GetByFilter(Expression<Func<Category, bool>> obj);
        void Save();
    }
}
