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
using System.Security.Permissions;
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
        public async Task<IEnumerable<FuncionarioViewModel>> ObterTodos(Expression<Func<Funcionario, bool>> predicate)
        {
            var obterTodos = await _funcionarioService.GetAll(o => o.Nome, predicate);
            return Declaracoes.mapper.Map<IEnumerable<FuncionarioViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<Funcionario, object>> order = null)
        {
            var combo = await _funcionarioService.ComboSearch(w => !w.Administrador, order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public async Task<IEnumerable<NomeComboViewModel>> ComboVendedor(Expression<Func<Funcionario, object>> order = null)
        {
            var combo = await _funcionarioService.ComboSearch(w => !w.Administrador, order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public async Task<IEnumerable<NomeComboViewModel>> ComboUsuario(Expression<Func<Funcionario, object>> order = null)
        {
            var combo = await _funcionarioService.ComboSearch(w => (((w.Administrador) || (w.EmpresaAcesso != null)) && (!w.Desativado)), order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public async Task<bool> ValidarSenha(Guid funcionarioId, string senha)
        {
            var funcionario = await _funcionarioService.GetById(funcionarioId);
            bool valido = false;

            if (funcionario != null)
            {
                if (funcionario.Senha.Trim() == senha.Trim())
                {
                    if ((funcionario.Administrador) || (funcionario.EmpresaAcesso != null))
                    {
                        Declaracoes.dados_funcionario = Declaracoes.mapper.Map<FuncionarioViewModel>(funcionario);

                        return true;
                    }
                }
            }

            return valido;
        }
        public void Dispose()
        {
            _funcionarioService.Dispose();
            MeuDbContext.Dispose();
        }
    }
}
