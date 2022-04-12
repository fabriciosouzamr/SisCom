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

        public async Task Adicionar(Pessoa pessoa)
        {
            if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                if (pessoa.TipoPessoa == Funcoes._Enum.TipoPessoaCliente.Juridica)
                {
                    var _pessoa = await _PessoaRepository.Search(f => f.CNPJ_CPF == pessoa.CNPJ_CPF);

                    if (_pessoa.Count() != 0)
                    {
                        Notify("Já existe uma pessoa com este C.N.P.J. informado.");
                        return;
                    }
                }

                await _PessoaRepository.Insert(pessoa);

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

                if (pessoa.TipoPessoa == Funcoes._Enum.TipoPessoaCliente.Juridica)
                {
                    var exists = _PessoaRepository.Exists(f => f.CNPJ_CPF == pessoa.CNPJ_CPF && f.Id != pessoa.Id);

                    if (exists)
                    {
                        Notify("Já existe uma pessoa com este C.N.P.J. informado.");
                        return;
                    }
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
