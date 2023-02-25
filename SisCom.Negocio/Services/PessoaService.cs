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
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IVendaRepository _vendaRepository;

        public PessoaService(IPessoaRepository pessoaRepository,
                             IVendaRepository vendaRepository,
                             INotifier notificador) : base(notificador, pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
            _vendaRepository = vendaRepository;
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                if (pessoa.TipoPessoa == Funcoes._Enum.TipoPessoaCliente.Juridica)
                {
                    var _pessoa = await _pessoaRepository.Search(f => f.CNPJ_CPF == pessoa.CNPJ_CPF);

                    if (_pessoa.Count() != 0)
                    {
                        Notify("Já existe uma pessoa com este C.N.P.J. informado.");
                        return;
                    }
                }

                await _pessoaRepository.Insert(pessoa);
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

                if (pessoa.TipoPessoa == Funcoes._Enum.TipoPessoaCliente.Juridica)
                {
                    var exists = _pessoaRepository.Exists(f => f.CNPJ_CPF == pessoa.CNPJ_CPF && f.Id != pessoa.Id);

                    if (exists)
                    {
                        Notify("Já existe uma pessoa com este C.N.P.J. informado.");
                        return;
                    }
                }

                await _pessoaRepository.Update(pessoa);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            if ((await _vendaRepository.Search(predicate: p => p.ClienteId == id)).Any())
            {
                Notify("Existe venda(s) relacionada(s) a esse cliente.");
                return false;
            }

            await _pessoaRepository.Delete(id);

            Notify("Exclusão Efetuada.");

            return true;
        }

        public Task<IPagedList<Pessoa>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _pessoaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public virtual async Task<List<Pessoa>> ComboFornecedor(Expression<Func<Pessoa, object>> order = null)
        {
            return await _pessoaRepository.ComboSearch(f => f.Fornecedor == true, order);
        }

        public override void Dispose()
        {
            _pessoaRepository?.Dispose();
        }
    }
}
