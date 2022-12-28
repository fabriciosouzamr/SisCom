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
    public class VeiculoPlacaController
    {
        static VeiculoPlacaService _VeiculoPlacaService;
        private readonly MeuDbContext MeuDbContext;

        public VeiculoPlacaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _VeiculoPlacaService = new VeiculoPlacaService(new VeiculoPlacaRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<VeiculoPlacaViewModel>> ObterTodos()
        {
            var obterTodos = await _VeiculoPlacaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<VeiculoPlacaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<VeiculoPlacaViewModel>> Combo(Expression<Func<VeiculoPlaca, object>> order = null)
        {
            var combo = await _VeiculoPlacaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<VeiculoPlacaViewModel>>(combo);
        }
    }
}
