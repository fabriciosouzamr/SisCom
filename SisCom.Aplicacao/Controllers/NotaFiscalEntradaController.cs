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
    public class NotaFiscalEntradaController : IDisposable
    {
        static NotaFiscalEntradaService _NotaFiscalEntradaService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalEntradaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalEntradaService = new NotaFiscalEntradaService(new NotaFiscalEntradaRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalEntradaViewModel> Adicionar(NotaFiscalEntradaViewModel NotaFiscalEntradaViewModel)
        {
            var NotaFiscalEntrada = Declaracoes.mapper.Map<NotaFiscalEntrada>(NotaFiscalEntradaViewModel);

            await _NotaFiscalEntradaService.Adicionar(NotaFiscalEntrada);

            return Declaracoes.mapper.Map<NotaFiscalEntradaViewModel>(NotaFiscalEntrada);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalEntradaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalEntradaViewModel> Atualizar(Guid id, NotaFiscalEntradaViewModel NotaFiscalEntradaViewModel)
        {
            await _NotaFiscalEntradaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalEntrada>(NotaFiscalEntradaViewModel));

            return NotaFiscalEntradaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalEntradaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalEntradaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalEntradaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalEntradaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalEntrada, object>> order = null)
        {
            var combo = await _NotaFiscalEntradaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            meuDbContext.Dispose();
        }

    }
}