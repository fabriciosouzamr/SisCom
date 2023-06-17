using Funcoes.Interfaces;
using Microsoft.EntityFrameworkCore;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class CidadeController: IDisposable
    {
        static CidadeService _CidadeService;
        private readonly MeuDbContext meuDbContext;

        public CidadeController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.meuDbContext = MeuDbContext;
            this.meuDbContext.Database.GetDbConnection();
            _CidadeService = new CidadeService(new CidadeRepository(this.meuDbContext), notifier);
        }
        public async Task<CidadeViewModel> Adicionar(CidadeViewModel CidadeViewModel)
        {
            await _CidadeService.Adicionar(Declaracoes.mapper.Map<Cidade>(CidadeViewModel));
            return CidadeViewModel;
        }
        public async Task<CidadeViewModel> Atualizar(CidadeViewModel CidadeViewModel)
        {
            await _CidadeService.Atualizar(Declaracoes.mapper.Map<Cidade>(CidadeViewModel));
            return CidadeViewModel;
        }
        public async Task Remover(Guid id)
        {
            await _CidadeService.Remover(id);
            return;
        }
        public async Task<CidadeViewModel> GetById(Guid id)
        {
            var obter = await _CidadeService.GetById(id);
            return Declaracoes.mapper.Map<CidadeViewModel>(obter);
        }
        public async Task<IEnumerable<CidadeViewModel>> GetByName(string nome)
        {
            var cidade = await _CidadeService.Search(f => f.Nome == nome);
            return Declaracoes.mapper.Map<IEnumerable<CidadeViewModel>>(cidade);
        }
        public async Task<IEnumerable<CidadeViewModel>> GetByIbgeCode(string codigoIbge)
        {
            var cidade = await _CidadeService.Search(f => f.CodigoIBGE == codigoIbge);
            return Declaracoes.mapper.Map<IEnumerable<CidadeViewModel>>(cidade);
        }
        public async Task<IEnumerable<CidadeViewModel>> ObterTodos(Expression<Func<Cidade, object>> order = null)
        {
            var obterTodos = await _CidadeService.GetAll(order: order, includes: i => i.Estado);
            return Declaracoes.mapper.Map<IEnumerable<CidadeViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CidadeComboViewModel>> Combo(Expression<Func<Cidade, object>> order = null)
        {
            var combo = await _CidadeService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CidadeComboViewModel>>(combo);
        }
        public async Task<IEnumerable<CidadeComboViewModel>> ComboEstado(Guid EstadoId, Expression<Func<Cidade, object>> order = null)
        {
            var combo = await _CidadeService.ComboSearch(p => p.EstadoId == EstadoId, order);
            return Declaracoes.mapper.Map<IEnumerable<CidadeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}