using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDAL<Entity> where Entity:class
    {
        void Add(Entity entity);
        void Update(Entity entity);
        void Delete(Expression<Func<Entity, bool>> obj);
        Entity GetByFilter(Expression<Func<Entity, bool>> obj);
        List<Entity> GetList(Expression<Func<Entity, bool>> obj = null);
        void Save();
    }
}
