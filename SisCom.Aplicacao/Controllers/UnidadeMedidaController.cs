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
    public class UnidadeMedidaController : IDisposable
    {
        static UnidadeMedidaService _UnidadeMedidaService;
        private readonly MeuDbContext MeuDbContext;

        public UnidadeMedidaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _UnidadeMedidaService = new UnidadeMedidaService(new UnidadeMedidaRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<UnidadeMedidaViewModel>> ObterTodos()
        {
            var obterTodos = await _UnidadeMedidaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<UnidadeMedidaViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoNomeComboViewModel>> Combo(Expression<Func<UnidadeMedida, object>> order = null)
        {
            var combo = await _UnidadeMedidaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
