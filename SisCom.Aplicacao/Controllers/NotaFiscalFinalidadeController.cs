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
    public class NotaFiscalFinalidadeController : IDisposable
    {
        static NotaFiscalFinalidadeService _NotaFiscalFinalidadeService;
        private readonly MeuDbContext MeuDbContext;

        public NotaFiscalFinalidadeController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _NotaFiscalFinalidadeService = new NotaFiscalFinalidadeService(new NotaFiscalFinalidadeRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<NotaFiscalFinalidadeViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalFinalidadeService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalFinalidadeViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalFinalidade, object>> order = null)
        {
            var combo = await _NotaFiscalFinalidadeService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}