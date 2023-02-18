using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaService : BaseService<NotaFiscalSaida>, INotaFiscalSaidaService
    {
        private readonly INotaFiscalSaidaRepository _notaFiscalSaidaRepository;

        public NotaFiscalSaidaService(INotaFiscalSaidaRepository NotaFiscalSaidaRepository,
                                     INotifier notificador) : base(notificador, NotaFiscalSaidaRepository)
        {
            _notaFiscalSaidaRepository = NotaFiscalSaidaRepository;
        }

        public Task<IPagedList<NotaFiscalSaida>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _notaFiscalSaidaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.NotaFiscal.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _notaFiscalSaidaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaida NotaFiscalSaida)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                var _NotaFiscalSaida = await _notaFiscalSaidaRepository.Search(f => ((f.CodigoChaveAcesso == NotaFiscalSaida.CodigoChaveAcesso) && (!String.IsNullOrEmpty(NotaFiscalSaida.CodigoChaveAcesso))));

                if (_NotaFiscalSaida.Any())
                {
                    Notify("Já existe uma Nota Fiscal de Saída com essa chave de acesso informado.");
                    return;
                }

                await _notaFiscalSaidaRepository.Insert(NotaFiscalSaida);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaida notaFiscalSaida)
        {
            try
            {
                var _notaFiscalSaidas = await _notaFiscalSaidaRepository.Search(f => ((f.CodigoChaveAcesso == notaFiscalSaida.CodigoChaveAcesso) && 
                                                                                     (!String.IsNullOrEmpty(notaFiscalSaida.CodigoChaveAcesso))) && (f.Id != notaFiscalSaida.Id));

                if (_notaFiscalSaidas.Any())
                {
                    Notify("Já existe uma Nota Fiscal de Saída com essa chave de acesso informado.");
                    return;
                }

                var _notaFiscalSaida = await _notaFiscalSaidaRepository.GetById(notaFiscalSaida.Id);

                if ((_notaFiscalSaida.Status == Entidade.Enum.NF_Status.Cancelado) &&
                    (_notaFiscalSaida.Status == Entidade.Enum.NF_Status.Finalizada) &&
                    (_notaFiscalSaida.Status == Entidade.Enum.NF_Status.Denegada) &&
                    (_notaFiscalSaida.Status == Entidade.Enum.NF_Status.Inutilizada) &&
                    (_notaFiscalSaida.Status == Entidade.Enum.NF_Status.Transmitida))
                {
                    _notaFiscalSaida.RetornoSefaz = notaFiscalSaida.RetornoSefaz;
                    _notaFiscalSaida.RetornoSefazCodigo = notaFiscalSaida.RetornoSefazCodigo;
                    _notaFiscalSaida.DataRetornoSefaz = notaFiscalSaida.DataRetornoSefaz;
                    _notaFiscalSaida.DescricaoCartaCorrecao = notaFiscalSaida.DescricaoCartaCorrecao;
                    _notaFiscalSaida.DataCartaCorrecao = notaFiscalSaida.DataCartaCorrecao;
                    _notaFiscalSaida.RetornoCartaCorrecao = notaFiscalSaida.RetornoCartaCorrecao;
                    _notaFiscalSaida.DescricaoCancelamento = notaFiscalSaida.DescricaoCancelamento;
                    _notaFiscalSaida.DataCancelamento = notaFiscalSaida.DataCancelamento;
                    _notaFiscalSaida.RetornoCancelamento = notaFiscalSaida.RetornoCancelamento;
                    _notaFiscalSaida.NumeroLoteEnvioSefaz = notaFiscalSaida.NumeroLoteEnvioSefaz;

                    await _notaFiscalSaidaRepository.Update(_notaFiscalSaida);
                }
                else
                {
                    await _notaFiscalSaidaRepository.Update(notaFiscalSaida);
                }

            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _notaFiscalSaidaRepository.Delete(id);
        }

    }
}
