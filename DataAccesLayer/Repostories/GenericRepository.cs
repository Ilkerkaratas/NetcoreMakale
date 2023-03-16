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
        //Bir entitiy alır ve içinde bulunduğu bilgileri veri tabanına ekler.
        public void Add(Entity entity)
        {
          
            db.Set<Entity>().Add(entity);
        }
        //veri tabanında var olan bir kayıtı günceller
        public void Update(Entity entity)
        {

            db.Set<Entity>().Update(entity);
        }
        //bir kayıtı linq sorgusuna göre siler.
        //not: birden fazla kayıtı silmek için döngünün içerisinde kullanılmalıdır.
        public void Delete(Expression<Func<Entity, bool>> obj)
        {
            var model = db.Set<Entity>().FirstOrDefault(obj);
            db.Set<Entity>().Remove(model);
        }
        //linq sorgusuna göre 1 kayıt getirir
        public Entity GetByFilter(Expression<Func<Entity, bool>> obj)
        {
            return db.Set<Entity>().FirstOrDefault(obj);
        }
        //linq sorgusunu karşılayan tablodaki bütün bilgileri getirir.
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
        //Ekleme, silme ve güncelleme işlemlerini yaptıktan sonra bu method çağrılmazsa veri tabanında bir değişiklik olmaz.
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
