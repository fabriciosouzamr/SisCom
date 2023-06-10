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
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class PessoaController : IDisposable
    {
        static PessoaService _pessoaService;
        private readonly MeuDbContext meuDbContext;

        public PessoaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;

            _pessoaService = new PessoaService(new PessoaRepository(meuDbContext), new VendaRepository(meuDbContext), notifier);
        }

        public async Task<PessoaViewModel> Adicionar(PessoaViewModel pessoaViewModel)
        {
            var pessoa = Declaracoes.mapper.Map<Pessoa>(pessoaViewModel);

            await _pessoaService.Adicionar(pessoa);

            return Declaracoes.mapper.Map<PessoaViewModel>(pessoa);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            return (await _pessoaService.Excluir(Id));
        }

        public async Task<PessoaViewModel> Atualizar(Guid id, PessoaViewModel pessoaViewModel)
        {
            await _pessoaService.Atualizar(Declaracoes.mapper.Map<Pessoa>(pessoaViewModel));

            return pessoaViewModel;
        }
        public async Task<IEnumerable<PessoaViewModel>> ObterTodos(Expression<Func<Pessoa, object>> order = null, Expression<Func<Pessoa, bool>> predicate = null, params Expression<Func<Pessoa, object>>[] includes)
        {
            var obterTodos = await _pessoaService.GetAll(order, predicate, includes);
            return Declaracoes.mapper.Map<IEnumerable<PessoaViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<PessoaViewModel>> PesquisarCNPJCPF(string CNPJCPF)
        {
            var pessoa = await _pessoaService.Search(p => p.CNPJ_CPF == CNPJCPF);
            return Declaracoes.mapper.Map<IEnumerable<PessoaViewModel>>(pessoa);
        }

        public async Task<IEnumerable<PessoaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _pessoaService.GetAll(null, p => p.Id == Id, i => i.Endereco, 
                                                                            i => i.Endereco.End_Cidade, 
                                                                            i => i.Endereco.End_Cidade.Estado,
                                                                            i => i.Endereco.End_Cidade.Estado.Pais);
            return Declaracoes.mapper.Map<IEnumerable<PessoaViewModel>>(pessoa);
        }

        public async Task<IEnumerable<PessoaComboNomeViewModel>> ComboNome(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _pessoaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboNomeViewModel>>(combo);
        }

        public async Task<IEnumerable<PessoaComboRazaoViewModel>> ComboRazaoSocial(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _pessoaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboRazaoViewModel>>(combo);
        }

        public async Task<IEnumerable<PessoaComboCodigoViewModel>> ComboCodigo(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _pessoaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboCodigoViewModel>>(combo);
        }

        public async Task<IEnumerable<PessoaComboCPFCNPJViewModel>> ComboCPFCNPJ(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _pessoaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboCPFCNPJViewModel>>(combo);
        }

        public async Task<IEnumerable<PessoaComboTelefoneViewModel>> ComboTelefone(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _pessoaService.ComboSearch(p => p.Telefone != null, order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboTelefoneViewModel>>(combo);
        }

        public async Task<IEnumerable<PessoaComboNomeViewModel>> ComboFornecedor(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _pessoaService.Search(p => p.Fornecedor == true, order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboNomeViewModel>>(combo);
        }
        public void Dispose()
        {
            //this.meuDbContext.Dispose();
        }
    }
}
