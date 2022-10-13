using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaPagamentoService : BaseService<NotaFiscalSaidaPagamento>, INotaFiscalSaidaPagamentoService
    {
        private readonly INotaFiscalSaidaPagamentoRepository _notaFiscalSaidaPagamentoRepository;

        public NotaFiscalSaidaPagamentoService(INotaFiscalSaidaPagamentoRepository NotaFiscalSaidaPagamentoRepository,
                                 INotifier notificador) : base(notificador, NotaFiscalSaidaPagamentoRepository)
        {
            _notaFiscalSaidaPagamentoRepository = NotaFiscalSaidaPagamentoRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaPagamento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _notaFiscalSaidaPagamentoRepository.GetPagedList(f =>
            (
                parameters.Search == null /* || f.Descricao.Contains(parameters.Search) */
            ), parameters);
        }

        public override void Dispose()
        {
            _notaFiscalSaidaPagamentoRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaidaPagamento NotaFiscalSaidaPagamento)
        {
            try
            {
                await _notaFiscalSaidaPagamentoRepository.Insert(NotaFiscalSaidaPagamento);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaidaPagamento NotaFiscalSaidaPagamento)
        {
            try
            {
                await _notaFiscalSaidaPagamentoRepository.Update(NotaFiscalSaidaPagamento);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public async Task Excluir(Guid id)
        {
            await _notaFiscalSaidaPagamentoRepository.Delete(id);
        }
    }
}
