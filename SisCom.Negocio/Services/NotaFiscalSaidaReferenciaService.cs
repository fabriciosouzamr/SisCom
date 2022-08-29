using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaReferenciaService : BaseService<NotaFiscalSaidaReferencia>, INotaFiscalSaidaReferenciaService
    {
        private readonly INotaFiscalSaidaReferenciaRepository _NotaFiscalSaidaReferenciaRepository;

        public NotaFiscalSaidaReferenciaService(INotaFiscalSaidaReferenciaRepository NotaFiscalSaidaReferenciaRepository,
                                 INotifier notificador) : base(notificador, NotaFiscalSaidaReferenciaRepository)
        {
            _NotaFiscalSaidaReferenciaRepository = NotaFiscalSaidaReferenciaRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaReferencia>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalSaidaReferenciaRepository.GetPagedList(f =>
            (
                parameters.Search == null /*|| f.Descricao.Contains(parameters.Search)*/
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalSaidaReferenciaRepository?.Dispose();
        }

        public Task Adicionar(NotaFiscalSaidaReferencia NotaFiscalSaidaReferencia)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(NotaFiscalSaidaReferencia NotaFiscalSaidaReferencia)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
