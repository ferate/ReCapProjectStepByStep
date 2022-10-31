﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        T GetById(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
