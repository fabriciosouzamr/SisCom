using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalEntradaFaturaService : BaseService<NotaFiscalEntradaFatura>, INotaFiscalEntradaFaturaService
    {
        private readonly INotaFiscalEntradaFaturaRepository _NotaFiscalEntradaFaturaRepository;

        public NotaFiscalEntradaFaturaService(INotaFiscalEntradaFaturaRepository NotaFiscalEntradaFaturaRepository,
                                              INotifier notificador) : base(notificador, NotaFiscalEntradaFaturaRepository)
        {
            _NotaFiscalEntradaFaturaRepository = NotaFiscalEntradaFaturaRepository;
        }
        public Task<IPagedList<NotaFiscalEntradaFatura>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalEntradaFaturaRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalEntradaFaturaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalEntradaFatura NotaFiscalEntradaFatura)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                var _NotaFiscalEntradaFatura = await _NotaFiscalEntradaFaturaRepository.Search(f => f.NotaFiscalEntradaId == NotaFiscalEntradaFatura.NotaFiscalEntradaId &&
                                                                                                    f.FormaPagamentoId == NotaFiscalEntradaFatura.FormaPagamentoId);

                if (_NotaFiscalEntradaFatura.Count() != 0)
                {
                    Notify("Já existe uma Fatura com essa forma de pagamento informada.");
                    return;
                }

                await _NotaFiscalEntradaFaturaRepository.Insert(NotaFiscalEntradaFatura);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalEntradaFatura NotaFiscalEntradaFatura)
        {
            try
            {
                var _NotaFiscalEntradaFatura = await _NotaFiscalEntradaFaturaRepository.Search(f => f.NotaFiscalEntradaId == NotaFiscalEntradaFatura.NotaFiscalEntradaId &&
                                                                                                    f.FormaPagamentoId == NotaFiscalEntradaFatura.FormaPagamentoId);

                if (_NotaFiscalEntradaFatura.Count() != 0)
                {
                    Notify("Já existe uma Fatura com essa forma de pagamento informada.");
                    return;
                }

                await _NotaFiscalEntradaFaturaRepository.Update(NotaFiscalEntradaFatura);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _NotaFiscalEntradaFaturaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public async Task ExcluirTodas(Guid id)
        {
            await _NotaFiscalEntradaFaturaRepository.Delete(w => w.NotaFiscalEntradaId == id);
        }

    }
}
