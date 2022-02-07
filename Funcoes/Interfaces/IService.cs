using Funcoes.Classes;
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
        Task<List<TEntity>> GetAll();
        //Task Atualizar(TEntity entity);
        //Task Remover(Guid id);
        //Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        //Task<int> SaveChanges();
    }
}
