using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TekhLoanManagement.Domain.Abstractions;

namespace TekhLoanManagement.Application.Interfaces
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<List<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task SaveChangesAsync();
        Task<List<TResult>> QueryAsync<TResult>(
       Expression<Func<TEntity, bool>>? predicate = null,
       Expression<Func<TEntity, TResult>> selector = null!,
       Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
       bool asNoTracking = true
   );
       Task<TResult?> QuerySingleAsync<TResult>(
       Expression<Func<TEntity, bool>> predicate,
       Expression<Func<TEntity, TResult>> selector,
       Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
       bool asNoTracking = true
   );


    }
}
