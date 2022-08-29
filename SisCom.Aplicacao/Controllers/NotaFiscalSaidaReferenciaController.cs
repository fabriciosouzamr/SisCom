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
    public class NotaFiscalSaidaReferenciaController : IDisposable
    {
        static NotaFiscalSaidaReferenciaService _NotaFiscalSaidaReferenciaService;
        private readonly MeuDbContext MeuDbContext;

        public NotaFiscalSaidaReferenciaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _NotaFiscalSaidaReferenciaService = new NotaFiscalSaidaReferenciaService(new NotaFiscalSaidaReferenciaRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<NotaFiscalSaidaReferenciaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalSaidaReferenciaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaReferenciaViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaReferencia, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaReferenciaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<NotaFiscalSaidaReferenciaViewModel> Adicionar(NotaFiscalSaidaReferenciaViewModel NotaFiscalSaidaReferenciaViewModel)
        {
            var NotaFiscalSaidaReferencia = Declaracoes.mapper.Map<NotaFiscalSaidaReferencia>(NotaFiscalSaidaReferenciaViewModel);

            await _NotaFiscalSaidaReferenciaService.Adicionar(NotaFiscalSaidaReferencia);

            return Declaracoes.mapper.Map<NotaFiscalSaidaReferenciaViewModel>(NotaFiscalSaidaReferencia);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
