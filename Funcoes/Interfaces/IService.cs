using Funcoes._Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes.Interfaces
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity
    {
        //Task Adicionar(TEntity entity);
        Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> order = null);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> order = null, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
        //Task Atualizar(TEntity entity);
        //Task Remover(Guid id);
        //Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        //Task<int> SaveChanges();
    }
}
