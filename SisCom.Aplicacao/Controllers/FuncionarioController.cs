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
    public class FuncionarioController
    {
        static FuncionarioService _FuncionarioService;
        private readonly MeuDbContext MeuDbContext;

        public FuncionarioController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _FuncionarioService = new FuncionarioService(new FuncionarioRepository(this.MeuDbContext), notifier);
        }

        public async Task<FuncionarioViewModel> Adicionar(FuncionarioViewModel FuncionarioViewModel)
        {
            await _FuncionarioService.Adicionar(Declaracoes.mapper.Map<Funcionario>(FuncionarioViewModel));

            return FuncionarioViewModel;
        }

        public async Task<FuncionarioViewModel> Atualizar(FuncionarioViewModel FuncionarioViewModel)
        {
            await _FuncionarioService.Atualizar(Declaracoes.mapper.Map<Funcionario>(FuncionarioViewModel));

            return FuncionarioViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _FuncionarioService.Remover(id);

            return;
        }

        public async Task<FuncionarioViewModel> GetById(Guid id)
        {
            var obter = await _FuncionarioService.GetById(id);
            return Declaracoes.mapper.Map<FuncionarioViewModel>(obter);
        }

        public async Task<FuncionarioViewModel> GetByName(string nome)
        {
            var grupo = await _FuncionarioService.Search(f => f.Nome == nome);
            return Declaracoes.mapper.Map<FuncionarioViewModel>(grupo);
        }

        public async Task<IEnumerable<FuncionarioViewModel>> ObterTodos()
        {
            var obterTodos = await _FuncionarioService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<FuncionarioViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<FuncionarioComboViewModel>> Combo(Expression<Func<Funcionario, object>> order = null)
        {
            var combo = await _FuncionarioService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<FuncionarioComboViewModel>>(combo);
        }

        public async Task<IEnumerable<FuncionarioComboViewModel>> ComboCodigo(Expression<Func<Funcionario, object>> order = null)
        {
            var combo = await _FuncionarioService.Combo(order);
            var ret = Declaracoes.mapper.Map<IEnumerable<FuncionarioComboViewModel>>(combo);

            return Declaracoes.mapper.Map<IEnumerable<FuncionarioComboViewModel>>(combo);
        }
    }
}
