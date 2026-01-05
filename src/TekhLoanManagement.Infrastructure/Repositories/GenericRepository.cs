using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TekhLoanManagement.Application.Interfaces;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : 
        IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> QueryAsync<TResult>(
            Expression<Func<TEntity, bool>>? predicate = null, 
            Expression<Func<TEntity, TResult>> selector = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
            , bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<TResult?> QuerySingleAsync<TResult>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
            bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
