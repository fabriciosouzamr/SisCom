using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
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
    public class TabelaSpedTipoItemController
    {
        static TabelaSpedTipoItemService _TabelaSpedTipoItemService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaSpedTipoItemController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaSpedTipoItemService = new TabelaSpedTipoItemService(new TabelaSpedTipoItemRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaSpedTipoItemViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaSpedTipoItemService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaSpedTipoItemViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<DescricaoComboViewModel>> Combo(Expression<Func<TabelaSpedTipoItem, object>> order = null)
        {
            var combo = await _TabelaSpedTipoItemService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<DescricaoComboViewModel>>(combo);
        }
    }
}
