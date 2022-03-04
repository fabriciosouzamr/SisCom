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
    public class FabricanteController
    {
        static FabricanteService _FabricanteService;
        private readonly MeuDbContext MeuDbContext;

        public FabricanteController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _FabricanteService = new FabricanteService(new FabricanteRepository(this.MeuDbContext), notifier);
        }

        public async Task<FabricanteViewModel> Adicionar(FabricanteViewModel fabricanteViewModel)
        {
            await _FabricanteService.Adicionar(SisCom.Aplicacao.Classes.Declaracoes.mapper.Map<Fabricante>(fabricanteViewModel));

            return fabricanteViewModel;
        }

        public async Task<FabricanteViewModel> Atualizar(Guid id, FabricanteViewModel fabricanteViewModel)
        {
            await _FabricanteService.Atualizar(SisCom.Aplicacao.Classes.Declaracoes.mapper.Map<Fabricante>(fabricanteViewModel));

            return fabricanteViewModel;
        }

        public async Task<FabricanteViewModel> Remover(Guid id)
        {
            await _FabricanteService.Remover(id);

            return null;
        }

        public async Task<IEnumerable<FabricanteViewModel>> ObterTodos(Expression<Func<Fabricante, object>> order = null)
        {
            var obterTodos = await _FabricanteService.GetAll(order);
            return SisCom.Aplicacao.Classes.Declaracoes.mapper.Map<IEnumerable<FabricanteViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<Fabricante, object>> order = null)
        {
            var combo = await _FabricanteService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

    }
}
