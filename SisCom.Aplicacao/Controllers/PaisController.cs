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
    public class PaisController : IDisposable
    {
        static PaisService _PaisService;
        private readonly MeuDbContext MeuDbContext;

        public PaisController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _PaisService = new PaisService(new PaisRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<PaisViewModel>> ObterTodos(Expression<Func<Pais, object>> order = null)
        {
            var obterTodos = await _PaisService.GetAll(order);
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<PaisViewModel>> Combo(Expression<Func<Pais, object>> order = null)
        {
            var combo = await _PaisService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(combo);
        }

        public async Task<IEnumerable<PaisViewModel>> ComboId(Guid Id)
        {
            var combo = await _PaisService.ComboSearch(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(combo);
        }
        public async Task Remover(Guid id)
        {
            await _PaisService.Excluir(id);

            return;
        }
        public async Task<PaisViewModel> Atualizar(PaisViewModel paisViewModel)
        {
            await _PaisService.Atualizar(Declaracoes.mapper.Map<Pais>(paisViewModel));

            return paisViewModel;
        }
        public async Task<PaisViewModel> Adicionar(PaisViewModel paisViewModel)
        {
            await _PaisService.Adicionar(Declaracoes.mapper.Map<Pais>(paisViewModel));

            return paisViewModel;
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
