using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HanaSolution.Services.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);

        // Marks an entity as modified
        T Update(T entity, List<Expression<Func<T, object>>> updateProperties = null, List<Expression<Func<T, object>>> excludeProperties = null);

        // Marks an entity to be removed
        T Delete(T entity);

        T Delete(int id);

        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> condition);

        // Get an entity by int id
        T GetById(int id);

        T GetByCondition(Expression<Func<T, bool>> condition, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);
        IEnumerable<T> GetAll(string[] includes, Expression<Func<T, bool>> condition);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> condition, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> condition, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> condition);

        bool CheckContains(Expression<Func<T, bool>> condition);
    }
}
