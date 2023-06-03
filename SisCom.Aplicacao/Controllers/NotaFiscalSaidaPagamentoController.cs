using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class NotaFiscalSaidaPagamentoController : IDisposable
    {
        static NotaFiscalSaidaPagamentoService _notaFiscalSaidaPagamentoService;
        private readonly MeuDbContext MeuDbContext;

        public NotaFiscalSaidaPagamentoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _notaFiscalSaidaPagamentoService = new NotaFiscalSaidaPagamentoService(new NotaFiscalSaidaPagamentoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<NotaFiscalSaidaPagamentoViewModel>> ObterTodos()
        {
            var obterTodos = await _notaFiscalSaidaPagamentoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaPagamentoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaPagamento, object>> order = null)
        {
            var combo = await _notaFiscalSaidaPagamentoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<NotaFiscalSaidaPagamentoViewModel> Adicionar(NotaFiscalSaidaPagamentoViewModel NotaFiscalSaidaPagamentoViewModel)
        {
            var NotaFiscalSaidaPagamento = Declaracoes.mapper.Map<NotaFiscalSaidaPagamento>(NotaFiscalSaidaPagamentoViewModel);

            await _notaFiscalSaidaPagamentoService.Adicionar(NotaFiscalSaidaPagamento);

            return Declaracoes.mapper.Map<NotaFiscalSaidaPagamentoViewModel>(NotaFiscalSaidaPagamento);
        }
        public async Task<NotaFiscalSaidaPagamentoViewModel> Atualizar(Guid id, NotaFiscalSaidaPagamentoViewModel NotaFiscalSaidaPagamentoViewModel)
        {
            await _notaFiscalSaidaPagamentoService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaPagamento>(NotaFiscalSaidaPagamentoViewModel));

            return NotaFiscalSaidaPagamentoViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaPagamentoViewModel>> PesquisarId(Guid Id)
        {
            var pagamento = await _notaFiscalSaidaPagamentoService.GetAll(predicate: p => p.NotaFiscalSaidaId == Id, order: o => o.DataVecimento, includes: i => i.FormaPagamento);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaPagamentoViewModel>>(pagamento);
        }
        public async Task Excluir(Guid id)
        {
            await _notaFiscalSaidaPagamentoService.Excluir(id);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
