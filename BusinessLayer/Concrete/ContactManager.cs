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
    public class ContactManager : IContactService
    {
        IContactDAL contactDAL;
        public ContactManager(IContactDAL dAL)
        {
            contactDAL = dAL;
        }
        public void Add(Contact entity)
        {
            contactDAL.Add(entity);
            contactDAL.Save();

        }
        public void Update(Contact entity)
        {
            contactDAL.Update(entity);
            contactDAL.Save();

        }

        public void Delete(Expression<Func<Contact, bool>> obj)
        {
            contactDAL.Delete(obj);
            contactDAL.Save();
        }

        public Contact GetByFilter(Expression<Func<Contact, bool>> obj)
        {
            return contactDAL.GetByFilter(obj);
        }

        public List<Contact> GetList(Expression<Func<Contact, bool>> obj = null)
        {
            if (obj == null)
            {
                return contactDAL.GetList();
            }
            else
            {
                return contactDAL.GetList(obj);

            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}