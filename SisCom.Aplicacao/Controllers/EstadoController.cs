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
    public class EstadoController
    {
        static EstadoService _EstadoService;
        private readonly MeuDbContext MeuDbContext;

        public EstadoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _EstadoService = new EstadoService(new EstadoRepository(this.MeuDbContext), notifier);
        }

        public async Task<EstadoViewModel> Adicionar(EstadoViewModel EstadoViewModel)
        {
            await _EstadoService.Adicionar(Declaracoes.mapper.Map<Estado>(EstadoViewModel));

            return EstadoViewModel;
        }

        public async Task<EstadoViewModel> Atualizar(EstadoViewModel EstadoViewModel)
        {
            await _EstadoService.Atualizar(Declaracoes.mapper.Map<Estado>(EstadoViewModel));

            return EstadoViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _EstadoService.Remover(id);

            return;
        }

        public async Task<EstadoViewModel> GetById(Guid id)
        {
            var obter = await _EstadoService.GetById(id);
            return Declaracoes.mapper.Map<EstadoViewModel>(obter);
        }

        public async Task<EstadoViewModel> GetByName(string nome)
        {
            var grupo = await _EstadoService.Search(f => f.Nome == nome);
            return Declaracoes.mapper.Map<EstadoViewModel>(grupo);
        }

        public async Task<IEnumerable<EstadoViewModel>> ObterTodos()
        {
            var obterTodos = await _EstadoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EstadoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoNomeComboViewModel>> Combo(Expression<Func<Estado, object>> order = null)
        {
            var combo = await _EstadoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);
        }

        public async Task<IEnumerable<CodigoNomeComboViewModel>> ComboCodigo(Expression<Func<Estado, object>> order = null)
        {
            var combo = await _EstadoService.Combo(order);
            var ret = Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);

            return Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);
        }
    }
}
