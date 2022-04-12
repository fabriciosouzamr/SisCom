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
    public class TabelaANPController
    {
        static TabelaANPService _TabelaANPService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaANPController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaANPService = new TabelaANPService(new TabelaANPRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaANPViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaANPService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaANPViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<TabelaANP, object>> order = null)
        {
            var combo = await _TabelaANPService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
