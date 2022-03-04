using Funcoes.Interfaces;
using Funcoes.PagedList;
using Microsoft.EntityFrameworkCore;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Funcoes._Entity;

namespace SisCom.Infraestrutura.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order = null)
        {
            if (order == null)
            {
                return await DbSet.Where(predicate).ToListAsync();
            }
            else
            {
                return await DbSet.Where(predicate).OrderBy(order ?? (e => e.Id)).ToListAsync();
            }
        }
        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).Any();
        }
        public virtual async Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            var includedData = DbSet.AsQueryable();
            foreach (var include in includes)
            {
                includedData = includedData.Include(include);
            }
            return await includedData.FirstOrDefaultAsync(p => p.Id == id);
        }
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Id == id);
        }
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> order = null)
        {
            return await DbSet.OrderBy(order ?? (e => e.Id)).ToListAsync();
        }
        public virtual async Task<List<TEntity>> Combo()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task<List<TEntity>> Combo(Expression<Func<TEntity, object>> order = null)
        {
            if (order==null)
            {
                return await DbSet.ToListAsync();
            }
            else
            {
                return await DbSet.OrderBy(order ?? (e => e.Id)).ToListAsync();
            }
        }
        public virtual async Task<List<TEntity>> ComboSearch(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order = null)
        {
            return await DbSet.Where(predicate).OrderBy(order ?? (e => e.Id)).ToListAsync();
        }
        public async Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate, PagedListParameters parameters)
        {
            var dadosFiltrados = DbSet.Where(predicate);
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TEntity>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
        public void BeginTransaction()
        {
            Db.Database.BeginTransaction();
        }
        public void Commit()
        {
            Db.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            Db.Database.RollbackTransaction();
        }
        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return Db.SaveChanges();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
