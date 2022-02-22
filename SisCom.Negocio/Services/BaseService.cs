﻿using FluentValidation;
using FluentValidation.Results;
using Funcoes._Entity;
using Funcoes.Interfaces;
using Funcoes.Notifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly INotifier _notifier;
        private readonly IRepository<TEntity> _repository;

        protected BaseService(INotifier notifier, IRepository<TEntity> repository)
        {
            _notifier = notifier;
            _repository = repository;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            if (_notifier != null)
            {
                _notifier.Handle(new Notification(mensagem));
            }
        }

        protected bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

        public virtual Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetById(id, includes);
        }

        public virtual Task<TEntity> GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public virtual Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Search(predicate);
        }

        public virtual Task<List<TEntity>> GetAll(Expression<Func<TEntity, object>> order = null)
        {
            return _repository.GetAll(order);
        }

        public virtual async Task<List<TEntity>> Combo(Expression<Func<TEntity, object>> order = null)
        {
            return await _repository.Combo(order);
        }

        public virtual async Task<List<TEntity>> ComboSearch(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> order = null)
        {
            return await _repository.ComboSearch(predicate, order);
        }

        //public virtual Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _repository.Buscar(predicate);
        //}

        //public virtual Task Adicionar(TEntity entity)
        //{
        //    return _repository.Adicionar(entity);
        //}

        //public virtual Task Atualizar(TEntity entity)
        //{
        //    return _repository.Atualizar(entity);
        //}

        //public virtual Task Remover(Guid id)
        //{
        //    return _repository.Remover(id);
        //}

        //public virtual Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _repository.Buscar(predicate);
        //}

        //public virtual Task<int> SaveChanges()
        //{
        //    return _repository.SaveChanges();
        //}

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
