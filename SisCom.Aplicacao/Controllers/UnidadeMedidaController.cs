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
        static UnidadeMedidaService unidadeMedidaService;
        private readonly MeuDbContext MeuDbContext;

        public UnidadeMedidaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            unidadeMedidaService = new UnidadeMedidaService(new UnidadeMedidaRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<UnidadeMedidaViewModel>> ObterTodos(Expression<Func<UnidadeMedida, object>> order = null)
        {
            var obterTodos = await unidadeMedidaService.GetAll(order);
            return Declaracoes.mapper.Map<IEnumerable<UnidadeMedidaViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoNomeComboViewModel>> Combo(Expression<Func<UnidadeMedida, object>> order = null)
        {
            var combo = await unidadeMedidaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);
        }
        public async Task<UnidadeMedidaViewModel> Adicionar(UnidadeMedidaViewModel unidadeMedidaViewModel)
        {
            await unidadeMedidaService.Adicionar(Declaracoes.mapper.Map<UnidadeMedida>(unidadeMedidaViewModel));

            return unidadeMedidaViewModel;
        }
        public async Task<UnidadeMedidaViewModel> Atualizar(UnidadeMedidaViewModel unidadeMedidaViewModel)
        {
            await unidadeMedidaService.Atualizar(Declaracoes.mapper.Map<UnidadeMedida>(unidadeMedidaViewModel));

            return unidadeMedidaViewModel;
        }
        public async Task Remover(Guid id)
        {
            await unidadeMedidaService.Excluir(id);

            return;
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
