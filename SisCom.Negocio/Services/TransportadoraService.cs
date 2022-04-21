using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TransportadoraService : BaseService<Transportadora>, ITransportadoraService
    {
        private readonly ITransportadoraRepository _transportadoraRepository;

        public TransportadoraService(ITransportadoraRepository transportadoraRepository,
                                     INotifier notificador) : base(notificador, transportadoraRepository)
        {
            _transportadoraRepository = transportadoraRepository;
        }

        public Task<IPagedList<Transportadora>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _transportadoraRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _transportadoraRepository?.Dispose();
        }

        public async Task Adicionar(Transportadora transportadora)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                if (transportadora.TipoPessoa == Funcoes._Enum.TipoPessoa.Juridica)
                {
                    var _transportadora = await _transportadoraRepository.Search(f => f.CNPJ_CPF == transportadora.CNPJ_CPF);

                    if (_transportadora.Count() != 0)
                    {
                        Notify("Já existe uma transportadora com este C.N.P.J. informado.");
                        return;
                    }
                }

                await _transportadoraRepository.Insert(transportadora);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(Transportadora transportadora)
        {
            try
            {
                //if (!RunValidation(new PessoaValidation(), pessoa)) return;

                if (transportadora.TipoPessoa == Funcoes._Enum.TipoPessoa.Juridica)
                {
                    var exists = _transportadoraRepository.Exists(f => f.CNPJ_CPF == transportadora.CNPJ_CPF && f.Id != transportadora.Id);

                    if (exists)
                    {
                        Notify("Já existe uma transportadora com este C.N.P.J. informado.");
                        return;
                    }
                }

                await _transportadoraRepository.Update(transportadora);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _transportadoraRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

    }
}
