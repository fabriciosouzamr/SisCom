using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _PessoaRepository;

        public PessoaService(IPessoaRepository PessoaRepository,
                             INotifier notificador) : base(notificador, PessoaRepository)
        {
            _PessoaRepository = PessoaRepository;
        }

        public async Task Adicionar(Pessoa Pessoa)
        {
            if (!RunValidation(new PessoaValidation(), Pessoa)) return;

            if (_PessoaRepository.Search(f => f.CNPJ_CPF == Pessoa.CNPJ_CPF).Result.Any())
            {
                Notify("Já existe uma pessoa com este C.P.F./C.N.P.J. informado.");
                return;
            }

            await _PessoaRepository.Insert(Pessoa);
        }

        public async Task Atualizar(Pessoa Pessoa)
        {
            if (!RunValidation(new PessoaValidation(), Pessoa)) return;

            if (_PessoaRepository.Search(f => f.CNPJ_CPF == Pessoa.CNPJ_CPF && f.Id != Pessoa.Id).Result.Any())
            {
                Notify("Já existe uma pessoa com este C.P.F./C.N.P.J. informado.");
                return;
            }

            await _PessoaRepository.Update(Pessoa);
        }

        public async Task Remover(Guid id)
        {
            await _PessoaRepository.Delete(id);
        }

        public Task<IPagedList<Pessoa>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _PessoaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public virtual async Task<List<Pessoa>> ComboFornecedor(Expression<Func<Pessoa, object>> order = null)
        {
            return await _PessoaRepository.ComboSearch(f => f.Fornecedor == true, order);
        }

        public override void Dispose()
        {
            _PessoaRepository?.Dispose();
        }
    }
}
