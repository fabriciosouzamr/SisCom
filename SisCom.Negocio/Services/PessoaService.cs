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

            try
            {
                var pessoa = await _PessoaRepository.Search(f => f.CNPJ_CPF == Pessoa.CNPJ_CPF);

                if (pessoa.Count() != 0)
                {
                    Notify("Já existe um fornecedor com este nome informado.");
                    return;
                }

                await _PessoaRepository.Insert(Pessoa);

                Notify("Gravação Efetuada.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(Pessoa pessoa)
        {
            try
            {
                if (!RunValidation(new PessoaValidation(), pessoa)) return;

                var exists = _PessoaRepository.Exists(f => f.CNPJ_CPF == pessoa.CNPJ_CPF && f.Id != pessoa.Id);

                if (exists)
                {
                    Notify("Já existe uma pessoa com este C.P.F./C.N.P.J. informado.");
                    return;
                }

                await _PessoaRepository.Update(pessoa);

                Notify("Atualização Efetuada.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _PessoaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
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
