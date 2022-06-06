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
    public class UnidadeMedidaConversaoController : IDisposable
    {
        static UnidadeMedidaConversaoService _UnidadeMedidaConversaoService;
        private readonly MeuDbContext MeuDbContext;

        public UnidadeMedidaConversaoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _UnidadeMedidaConversaoService = new UnidadeMedidaConversaoService(new UnidadeMedidaConversaoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<UnidadeMedidaConversaoViewModel>> ObterTodos()
        {
            var obterTodos = await _UnidadeMedidaConversaoService.GetAll(o => o.Id, i => i.UnidadeMedidaA, p => p.UnidadeMedidaB);
            return Declaracoes.mapper.Map<IEnumerable<UnidadeMedidaConversaoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<UnidadeMedidaConversao, object>> order = null)
        {
            var combo = await _UnidadeMedidaConversaoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
