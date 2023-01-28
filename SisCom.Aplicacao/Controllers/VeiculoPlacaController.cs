using Funcoes._Entity;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class VeiculoPlacaController : IDisposable
    {
        static VeiculoPlacaService veiculoPlacaService;
        private readonly MeuDbContext meuDbContext;

        public VeiculoPlacaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.meuDbContext = MeuDbContext;

            veiculoPlacaService = new VeiculoPlacaService(new VeiculoPlacaRepository(this.meuDbContext), notifier);
        }
        public async Task<IEnumerable<VeiculoPlacaViewModel>> ObterTodos(Expression<Func<VeiculoPlaca, object>> order = null, 
                                                                         Expression<Func<VeiculoPlaca, bool>> predicate = null, 
                                                                         params Expression<Func<VeiculoPlaca, object>>[] includes)
        {
            var obterTodos = await veiculoPlacaService.GetAll(order: order, predicate: predicate, includes: includes);
            return Declaracoes.mapper.Map<IEnumerable<VeiculoPlacaViewModel>>(obterTodos);
        }
        public async Task<VeiculoPlacaViewModel> GetById(Guid id)
        {
            var obter = await veiculoPlacaService.GetById(id);
            return Declaracoes.mapper.Map<VeiculoPlacaViewModel>(obter);
        }
        public async Task<IEnumerable<VeiculoPlacaViewModel>> Combo(Expression<Func<VeiculoPlaca, object>> order = null)
        {
            var combo = await veiculoPlacaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<VeiculoPlacaViewModel>>(combo);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await veiculoPlacaService.Excluir(Id);

            return true;
        }
        public async Task<VeiculoPlacaViewModel> Adicionar(VeiculoPlacaViewModel veiculoPlacaViewModel)
        {
            var veiculoPlaca = Declaracoes.mapper.Map<VeiculoPlaca>(veiculoPlacaViewModel);

            await veiculoPlacaService.Adicionar(veiculoPlaca);

            return Declaracoes.mapper.Map<VeiculoPlacaViewModel>(veiculoPlaca);
        }
        public async Task<VeiculoPlacaViewModel> Atualizar(Guid id, VeiculoPlacaViewModel veiculoPlacaViewModel)
        {
            await veiculoPlacaService.Atualizar(Declaracoes.mapper.Map<VeiculoPlaca>(veiculoPlacaViewModel));

            return veiculoPlacaViewModel;
        }
        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}
