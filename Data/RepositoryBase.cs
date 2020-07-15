using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;

namespace VueAsp.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BazaDataBase RepositoryContext { get; set; }
        public RepositoryBase(BazaDataBase repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }
    }
}
