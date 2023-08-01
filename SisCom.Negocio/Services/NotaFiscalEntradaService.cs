using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalEntradaService : BaseService<NotaFiscalEntrada>, INotaFiscalEntradaService
    {
        private readonly INotaFiscalEntradaRepository _NotaFiscalEntradaRepository;

        public NotaFiscalEntradaService(INotaFiscalEntradaRepository NotaFiscalEntradaRepository,
                                     INotifier notificador) : base(notificador, NotaFiscalEntradaRepository)
        {
            _NotaFiscalEntradaRepository = NotaFiscalEntradaRepository;
        }

        public Task<IPagedList<NotaFiscalEntrada>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalEntradaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.NotaFiscal.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalEntradaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalEntrada NotaFiscalEntrada)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                var _NotaFiscalEntrada = await _NotaFiscalEntradaRepository.Search(f => f.CodigoChaveAcesso == NotaFiscalEntrada.CodigoChaveAcesso);

                if (_NotaFiscalEntrada.Count() != 0)
                {
                    Notify("Já existe uma Nota Fiscal de Entrada com essa chave de acesso informado.");
                    return;
                }

                await _NotaFiscalEntradaRepository.Insert(NotaFiscalEntrada);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalEntrada notaFiscalEntrada)
        {
            try
            {
                var _NotaFiscalEntrada = await _NotaFiscalEntradaRepository.Search(f => f.CodigoChaveAcesso == notaFiscalEntrada.CodigoChaveAcesso && f.Id != notaFiscalEntrada.Id);

                if (_NotaFiscalEntrada.Count() != 0)
                {
                    Notify("Já existe uma Nota Fiscal de Entrada com essa chave de acesso informado.");
                    return;
                }

                await _NotaFiscalEntradaRepository.Update(notaFiscalEntrada);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _NotaFiscalEntradaRepository.Delete(id);
        }

    }
}
