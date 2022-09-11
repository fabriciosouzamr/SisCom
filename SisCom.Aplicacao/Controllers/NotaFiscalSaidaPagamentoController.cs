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
        static NotaFiscalSaidaPagamentoService _NotaFiscalSaidaPagamentoService;
        private readonly MeuDbContext MeuDbContext;

        public NotaFiscalSaidaPagamentoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _NotaFiscalSaidaPagamentoService = new NotaFiscalSaidaPagamentoService(new NotaFiscalSaidaPagamentoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<NotaFiscalSaidaPagamentoViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalSaidaPagamentoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaPagamentoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaPagamento, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaPagamentoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<NotaFiscalSaidaPagamentoViewModel> Adicionar(NotaFiscalSaidaPagamentoViewModel NotaFiscalSaidaPagamentoViewModel)
        {
            var NotaFiscalSaidaPagamento = Declaracoes.mapper.Map<NotaFiscalSaidaPagamento>(NotaFiscalSaidaPagamentoViewModel);

            await _NotaFiscalSaidaPagamentoService.Adicionar(NotaFiscalSaidaPagamento);

            return Declaracoes.mapper.Map<NotaFiscalSaidaPagamentoViewModel>(NotaFiscalSaidaPagamento);
        }
        public async Task<NotaFiscalSaidaPagamentoViewModel> Atualizar(Guid id, NotaFiscalSaidaPagamentoViewModel NotaFiscalSaidaPagamentoViewModel)
        {
            await _NotaFiscalSaidaPagamentoService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaPagamento>(NotaFiscalSaidaPagamentoViewModel));

            return NotaFiscalSaidaPagamentoViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaPagamentoViewModel>> PesquisarId(Guid Id)
        {
            var pagamento = await _NotaFiscalSaidaPagamentoService.GetAll(null, p => p.NotaFiscalSaidaId == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaPagamentoViewModel>>(pagamento);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
