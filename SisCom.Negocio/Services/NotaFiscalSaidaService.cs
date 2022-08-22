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
        private readonly INotaFiscalSaidaRepository _NotaFiscalSaidaRepository;

        public NotaFiscalSaidaService(INotaFiscalSaidaRepository NotaFiscalSaidaRepository,
                                     INotifier notificador) : base(notificador, NotaFiscalSaidaRepository)
        {
            _NotaFiscalSaidaRepository = NotaFiscalSaidaRepository;
        }

        public Task<IPagedList<NotaFiscalSaida>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalSaidaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.NumeroNotaFiscalSaida.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalSaidaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaida NotaFiscalSaida)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                var _NotaFiscalSaida = await _NotaFiscalSaidaRepository.Search(f => f.CodigoChaveAcesso == NotaFiscalSaida.CodigoChaveAcesso);

                if (_NotaFiscalSaida.Count() != 0)
                {
                    Notify("Já existe uma Nota Fiscal de Saída com essa chave de acesso informado.");
                    return;
                }

                await _NotaFiscalSaidaRepository.Insert(NotaFiscalSaida);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaida NotaFiscalSaida)
        {
            try
            {
                var _NotaFiscalSaida = await _NotaFiscalSaidaRepository.Search(f => f.CodigoChaveAcesso == NotaFiscalSaida.CodigoChaveAcesso);

                if (_NotaFiscalSaida.Count() != 0)
                {
                    Notify("Já existe uma Nota Fiscal de Saída com essa chave de acesso informado.");
                    return;
                }

                await _NotaFiscalSaidaRepository.Update(NotaFiscalSaida);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _NotaFiscalSaidaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

    }
}
