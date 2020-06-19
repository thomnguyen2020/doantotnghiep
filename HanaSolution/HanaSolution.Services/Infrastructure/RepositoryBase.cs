using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HanaSolution.Services.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties

        private EntitiesDbContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected EntitiesDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        #endregion Properties

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }


        public T Update(T entity, List<Expression<Func<T, object>>> updateProperties = null, List<Expression<Func<T, object>>> excludeProperties = null)
        {
            dbSet.Attach(entity);

            if (updateProperties == null || updateProperties.Count == 0)
            {
                DbContext.Entry<T>(entity).State = EntityState.Modified;
                if (excludeProperties != null && excludeProperties.Count > 0)
                {
                    excludeProperties.ForEach(p => DbContext.Entry<T>(entity).Property(p).IsModified = false);
                }
            }
            else
            {
                updateProperties.ForEach(p => DbContext.Entry<T>(entity).Property(p).IsModified = true);
            }

            return entity;
        }

        public T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public void DeleteMulti(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> objects = dbSet.Where<T>(condition).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return dataContext.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dataContext.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition, string includes)
        {
            return dbSet.Where(condition).ToList();
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> condition, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(condition).AsQueryable<T>();
            }

            return dataContext.Set<T>().Where<T>(condition).AsQueryable<T>();
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE a
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = filter != null ? query.Where<T>(filter).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = filter != null ? dataContext.Set<T>().Where<T>(filter).AsQueryable() : dataContext.Set<T>().AsQueryable();
            }
            total = _resetSet.Count();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            return _resetSet.AsQueryable();
        }

        public int Count(Expression<Func<T, bool>> condition)
        {
            return dbSet.Count(condition);
        }

        public bool CheckContains(Expression<Func<T, bool>> condition)
        {
            return dataContext.Set<T>().Count<T>(condition) > 0;
        }

        public IEnumerable<T> GetAll(string[] includes, Expression<Func<T, bool>> condition)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(condition).AsQueryable();
            }

            return dataContext.Set<T>().Where<T>(condition).AsQueryable();
        }
        #endregion
    }
}
