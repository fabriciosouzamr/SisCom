using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaPagamentoService : BaseService<NotaFiscalSaidaPagamento>, INotaFiscalSaidaPagamentoService
    {
        private readonly INotaFiscalSaidaPagamentoRepository _NotaFiscalSaidaPagamentoRepository;

        public NotaFiscalSaidaPagamentoService(INotaFiscalSaidaPagamentoRepository NotaFiscalSaidaPagamentoRepository,
                                 INotifier notificador) : base(notificador, NotaFiscalSaidaPagamentoRepository)
        {
            _NotaFiscalSaidaPagamentoRepository = NotaFiscalSaidaPagamentoRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaPagamento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalSaidaPagamentoRepository.GetPagedList(f =>
            (
                parameters.Search == null /* || f.Descricao.Contains(parameters.Search) */
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalSaidaPagamentoRepository?.Dispose();
        }

        public Task Adicionar(NotaFiscalSaidaPagamento NotaFiscalSaidaPagamento)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(NotaFiscalSaidaPagamento NotaFiscalSaidaPagamento)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
