using Funcoes._Entity;
using Funcoes.PagedList;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Funcoes.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Insert(TEntity entity);
        Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> order = null);
        Task<List<TEntity>> Combo(Expression<Func<TEntity, object>> order = null);
        Task<List<TEntity>> ComboSearch(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order = null);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        public Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate, PagedListParameters parameters);
        Task<int> SaveChanges();

        public void BeginTransaction();
        public void Commit();
        public void RollbackTransaction();
    }
}
