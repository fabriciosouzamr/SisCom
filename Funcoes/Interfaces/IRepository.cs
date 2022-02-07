using Funcoes.Classes;
using Funcoes.PagedList;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Insert(TEntity entity);
        Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> Combo();

        Task<List<TEntity>> ComboSearch(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        public Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate, PagedListParameters parameters);
        Task<int> SaveChanges();

        public void BeginTransaction();
        public void Commit();
        public void RollbackTransaction();
    }
}
