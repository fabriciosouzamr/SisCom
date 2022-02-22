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
    public class CidadeController
    {
        static CidadeService _CidadeService;
        private readonly MeuDbContext MeuDbContext;

        public CidadeController(MeuDbContext MeuDbContext)
        {
            this.MeuDbContext = MeuDbContext;

            _CidadeService = new CidadeService(new CidadeRepository(this.MeuDbContext), null);
        }

        public async Task<CidadeViewModel> Adicionar(CidadeViewModel CidadeViewModel)
        {
            await _CidadeService.Adicionar(Declaracoes.mapper.Map<Cidade>(CidadeViewModel));

            return CidadeViewModel;
        }

        public async Task<CidadeViewModel> Atualizar(CidadeViewModel CidadeViewModel)
        {
            await _CidadeService.Atualizar(Declaracoes.mapper.Map<Cidade>(CidadeViewModel));

            return CidadeViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _CidadeService.Remover(id);

            return;
        }

        public async Task<CidadeViewModel> GetById(Guid id)
        {
            var obter = await _CidadeService.GetById(id);
            return Declaracoes.mapper.Map<CidadeViewModel>(obter);
        }

        public async Task<CidadeViewModel> GetByName(string nome)
        {
            var grupo = await _CidadeService.Search(f => f.Nome == nome);
            return Declaracoes.mapper.Map<CidadeViewModel>(grupo);
        }

        public async Task<IEnumerable<CidadeViewModel>> ObterTodos()
        {
            var obterTodos = await _CidadeService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<CidadeViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CidadeComboViewModel>> Combo(Expression<Func<Cidade, object>> order = null)
        {
            var combo = await _CidadeService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CidadeComboViewModel>>(combo);
        }

        public async Task<IEnumerable<CidadeComboViewModel>> ComboEstado(Guid EstadoId, Expression<Func<Cidade, object>> order = null)
        {
            var combo = await _CidadeService.ComboSearch(p => p.EstadoId == EstadoId, order);
            return Declaracoes.mapper.Map<IEnumerable<CidadeComboViewModel>>(combo);
        }
    }
}
