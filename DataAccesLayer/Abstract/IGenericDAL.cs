using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDAL<Entity> where Entity:class
       
    {
        void Delete(Expression<Func<Entity, bool>> obj);
        void Add(Entity entity);
        void Update(Entity entity);
      
        List<Entity> GetList(Expression<Func<Entity, bool>> obj = null);
        Entity GetByFilter(Expression<Func<Entity, bool>> obj);
        void Save();


    }
}
