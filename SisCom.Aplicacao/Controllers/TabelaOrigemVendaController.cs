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
    public class TabelaOrigemVendaController : IDisposable
    {
        static TabelaOrigemVendaService _TabelaOrigemVendaService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaOrigemVendaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaOrigemVendaService = new TabelaOrigemVendaService(new TabelaOrigemVendaRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaOrigemVendaViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaOrigemVendaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaOrigemVendaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<DescricaoComboViewModel>> Combo(Expression<Func<TabelaOrigemVenda, object>> order = null)
        {
            var combo = await _TabelaOrigemVendaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<DescricaoComboViewModel>>(combo);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
