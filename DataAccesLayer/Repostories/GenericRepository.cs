using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repostories
{
     public class GenericRepostory<Entity> : IGenericDAL<Entity>
        where Entity : class, new()
        
    {
        Context db = new Context();

        public void Add(Entity entity)
        {
          
            db.Set<Entity>().Add(entity);
        }
        public void Update(Entity entity)
        {

            db.Set<Entity>().Update(entity);
        }
        public void Delete(Expression<Func<Entity, bool>> obj)
        {
            var model = db.Set<Entity>().FirstOrDefault(obj);
            db.Set<Entity>().Remove(model);
        }

        public Entity GetByFilter(Expression<Func<Entity, bool>> obj)
        {
            return db.Set<Entity>().FirstOrDefault(obj);
        }

        public List<Entity> GetList(Expression<Func<Entity, bool>> obj = null)
        {
            List<Entity> liste;
            if (obj == null)
            {
                liste = db.Set<Entity>().ToList();
            }
            else
            {
                liste = db.Set<Entity>().Where(obj).ToList();
            }
            return liste;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
