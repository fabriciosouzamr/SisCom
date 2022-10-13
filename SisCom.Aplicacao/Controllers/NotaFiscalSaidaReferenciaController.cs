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
    public class NotaFiscalSaidaReferenciaController : IDisposable
    {
        static NotaFiscalSaidaReferenciaService _notaFiscalSaidaReferenciaService;
        private readonly MeuDbContext MeuDbContext;

        public NotaFiscalSaidaReferenciaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _notaFiscalSaidaReferenciaService = new NotaFiscalSaidaReferenciaService(new NotaFiscalSaidaReferenciaRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<NotaFiscalSaidaReferenciaViewModel>> ObterTodos()
        {
            var obterTodos = await _notaFiscalSaidaReferenciaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaReferenciaViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaReferencia, object>> order = null)
        {
            var combo = await _notaFiscalSaidaReferenciaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<NotaFiscalSaidaReferenciaViewModel> Adicionar(NotaFiscalSaidaReferenciaViewModel NotaFiscalSaidaReferenciaViewModel)
        {
            var NotaFiscalSaidaReferencia = Declaracoes.mapper.Map<NotaFiscalSaidaReferencia>(NotaFiscalSaidaReferenciaViewModel);

            await _notaFiscalSaidaReferenciaService.Adicionar(NotaFiscalSaidaReferencia);

            return Declaracoes.mapper.Map<NotaFiscalSaidaReferenciaViewModel>(NotaFiscalSaidaReferencia);
        }
        public async Task<NotaFiscalSaidaReferenciaViewModel> Atualizar(Guid id, NotaFiscalSaidaReferenciaViewModel NotaFiscalSaidaReferenciaViewModel)
        {
            await _notaFiscalSaidaReferenciaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaReferencia>(NotaFiscalSaidaReferenciaViewModel));

            return NotaFiscalSaidaReferenciaViewModel;
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _notaFiscalSaidaReferenciaService.Excluir(Id);

            return true;
        }
        public async Task<IEnumerable<NotaFiscalSaidaReferenciaViewModel>> PesquisarId(Guid Id)
        {
            var pagamento = await _notaFiscalSaidaReferenciaService.GetAll(null, p => p.NotaFiscalSaidaId == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaReferenciaViewModel>>(pagamento);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
