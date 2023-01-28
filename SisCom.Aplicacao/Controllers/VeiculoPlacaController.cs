using Funcoes._Entity;
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
    public class VeiculoPlacaController : IDisposable
    {
        static VeiculoPlacaService _VeiculoPlacaService;
        private readonly MeuDbContext meuDbContext;

        public VeiculoPlacaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.meuDbContext = MeuDbContext;

            _VeiculoPlacaService = new VeiculoPlacaService(new VeiculoPlacaRepository(this.meuDbContext), notifier);
        }
        public async Task<IEnumerable<VeiculoPlacaViewModel>> ObterTodos(Expression<Func<VeiculoPlaca, object>> order = null, 
                                                                         Expression<Func<VeiculoPlaca, bool>> predicate = null, 
                                                                         params Expression<Func<VeiculoPlaca, object>>[] includes)
        {
            var obterTodos = await _VeiculoPlacaService.GetAll(order: order, predicate: predicate, includes: includes);
            return Declaracoes.mapper.Map<IEnumerable<VeiculoPlacaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<VeiculoPlacaViewModel>> Combo(Expression<Func<VeiculoPlaca, object>> order = null)
        {
            var combo = await _VeiculoPlacaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<VeiculoPlacaViewModel>>(combo);
        }
        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}
