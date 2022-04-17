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
    public class TabelaSpedCodigoGeneroController
    {
        static TabelaSpedCodigoGeneroService _TabelaSpedCodigoGeneroService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaSpedCodigoGeneroController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaSpedCodigoGeneroService = new TabelaSpedCodigoGeneroService(new TabelaSpedCodigoGeneroRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaSpedCodigoGeneroViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaSpedCodigoGeneroService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaSpedCodigoGeneroViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<TabelaSpedCodigoGenero, object>> order = null)
        {
            var combo = await _TabelaSpedCodigoGeneroService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
