using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using SearchEngine.Core.Entities;

namespace SearchEngine.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Updated(T entity);
        void Delete(T entity);
    }
}
