using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalFinalidadeService : BaseService<NotaFiscalFinalidade>, INotaFiscalFinalidadeService
    {
        private readonly INotaFiscalFinalidadeRepository _NotaFiscalFinalidadeRepository;

        public NotaFiscalFinalidadeService(INotaFiscalFinalidadeRepository NotaFiscalFinalidadeRepository,
                                        INotifier notificador) : base(notificador, NotaFiscalFinalidadeRepository)
        {
            _NotaFiscalFinalidadeRepository = NotaFiscalFinalidadeRepository;
        }

        public Task<IPagedList<NotaFiscalFinalidade>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalFinalidadeRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalFinalidadeRepository?.Dispose();
        }

        public Task Adicionar(NotaFiscalFinalidade NotaFiscalFinalidade)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(NotaFiscalFinalidade NotaFiscalFinalidade)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
