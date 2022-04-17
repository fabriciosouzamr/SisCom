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
    public class TabelaSpedInformacaoAdicionalItemController
    {
        static TabelaSpedInformacaoAdicionalItemService _TabelaSpedInformacaoAdicionalItemService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaSpedInformacaoAdicionalItemController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaSpedInformacaoAdicionalItemService = new TabelaSpedInformacaoAdicionalItemService(new TabelaSpedInformacaoAdicionalItemRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaSpedInformacaoAdicionalItemViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaSpedInformacaoAdicionalItemService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaSpedInformacaoAdicionalItemViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<TabelaSpedInformacaoAdicionalItem, object>> order = null)
        {
            var combo = await _TabelaSpedInformacaoAdicionalItemService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
