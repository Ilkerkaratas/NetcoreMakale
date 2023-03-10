﻿using BusinessLayer.Abstract;
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
    public class LikeManager : ILikeService
    {
        ILikeDAL dAL;
        public LikeManager( ILikeDAL _DAL)
        {
            dAL = _DAL;
        }
        public void Add(Like entity)
        {
            dAL.Add(entity);
            dAL.Save();
        }

        public void Delete(Expression<Func<Like, bool>> obj)
        {
            dAL.Delete(obj);
            dAL.Save();
        }

        public Like GetByFilter(Expression<Func<Like, bool>> obj)
        {
            return dAL.GetByFilter(obj);
        }

        public List<Like> GetList(Expression<Func<Like, bool>> obj = null)
        {
            return dAL.GetList(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Like entity)
        {
            dAL.Update(entity);
            dAL.Save();
        }

        public bool varmi(int id)
        {
            return dAL.varmi(id);
        }
    }
}