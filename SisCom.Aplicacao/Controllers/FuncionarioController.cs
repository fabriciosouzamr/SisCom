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
    public class FuncionarioController: IDisposable
    {
        static FuncionarioService _funcionarioService;
        private readonly MeuDbContext MeuDbContext;

        public FuncionarioController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _funcionarioService = new FuncionarioService(new FuncionarioRepository(meuDbContext), notifier);
        }
        public async Task<FuncionarioViewModel> Adicionar(FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = Declaracoes.mapper.Map<Funcionario>(funcionarioViewModel);

            await _funcionarioService.Adicionar(funcionario);

            return Declaracoes.mapper.Map<FuncionarioViewModel>(funcionario);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _funcionarioService.Excluir(Id);

            return true;
        }
        public async Task<FuncionarioViewModel> Atualizar(Guid id, FuncionarioViewModel funcionarioViewModel)
        {
            await _funcionarioService.Atualizar(Declaracoes.mapper.Map<Funcionario>(funcionarioViewModel));

            return funcionarioViewModel;
        }
        public async Task<IEnumerable<FuncionarioViewModel>> ObterTodos()
        {
            var obterTodos = await _funcionarioService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<FuncionarioViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<CodigoNomeComboViewModel>> Combo(Expression<Func<Funcionario, object>> order = null)
        {
            var combo = await _funcionarioService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            _funcionarioService.Dispose();
            MeuDbContext.Dispose();
        }
    }
}
