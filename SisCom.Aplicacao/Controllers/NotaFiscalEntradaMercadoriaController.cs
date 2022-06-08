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
    public class NotaFiscalEntradaMercadoriaController : IDisposable
    {
        static NotaFiscalEntradaMercadoriaService _NotaFiscalEntradaMercadoriaService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalEntradaMercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalEntradaMercadoriaService = new NotaFiscalEntradaMercadoriaService(new NotaFiscalEntradaMercadoriaRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalEntradaMercadoriaViewModel> Adicionar(NotaFiscalEntradaMercadoriaViewModel NotaFiscalEntradaMercadoriaViewModel)
        {
            var NotaFiscalEntradaMercadoria = Declaracoes.mapper.Map<NotaFiscalEntradaMercadoria>(NotaFiscalEntradaMercadoriaViewModel);

            await _NotaFiscalEntradaMercadoriaService.Adicionar(NotaFiscalEntradaMercadoria);

            return Declaracoes.mapper.Map<NotaFiscalEntradaMercadoriaViewModel>(NotaFiscalEntradaMercadoria);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalEntradaMercadoriaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalEntradaMercadoriaViewModel> Atualizar(Guid id, NotaFiscalEntradaMercadoriaViewModel NotaFiscalEntradaMercadoriaViewModel)
        {
            await _NotaFiscalEntradaMercadoriaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalEntradaMercadoria>(NotaFiscalEntradaMercadoriaViewModel));

            return NotaFiscalEntradaMercadoriaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalEntradaMercadoriaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalEntradaMercadoriaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalEntradaMercadoria, object>> order = null)
        {
            var combo = await _NotaFiscalEntradaMercadoriaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}