using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        void Delete(Expression<Func<Contact, bool>> obj);
        void Add(Contact entity);
        void Update(Contact category);
        List<Contact> GetList(Expression<Func<Contact, bool>> obj = null);
        Contact GetByFilter(Expression<Func<Contact, bool>> obj);
        void Save();
    }
}
