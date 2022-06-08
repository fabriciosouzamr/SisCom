using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class NotaFiscalEntradaFaturaController : IDisposable
    {
        static NotaFiscalEntradaFaturaService _NotaFiscalEntradaFaturaService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalEntradaFaturaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalEntradaFaturaService = new NotaFiscalEntradaFaturaService(new NotaFiscalEntradaFaturaRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalEntradaFaturaViewModel> Adicionar(NotaFiscalEntradaFaturaViewModel NotaFiscalEntradaFaturaViewModel)
        {
            var NotaFiscalEntradaFatura = Declaracoes.mapper.Map<NotaFiscalEntradaFatura>(NotaFiscalEntradaFaturaViewModel);

            await _NotaFiscalEntradaFaturaService.Adicionar(NotaFiscalEntradaFatura);

            return Declaracoes.mapper.Map<NotaFiscalEntradaFaturaViewModel>(NotaFiscalEntradaFatura);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalEntradaFaturaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalEntradaFaturaViewModel> Atualizar(Guid id, NotaFiscalEntradaFaturaViewModel NotaFiscalEntradaFaturaViewModel)
        {
            await _NotaFiscalEntradaFaturaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalEntradaFatura>(NotaFiscalEntradaFaturaViewModel));

            return NotaFiscalEntradaFaturaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalEntradaFaturaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalEntradaFaturaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaFaturaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalEntradaFaturaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalEntradaFaturaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaFaturaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalEntradaFatura, object>> order = null)
        {
            var combo = await _NotaFiscalEntradaFaturaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}