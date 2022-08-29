using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaObservacaoService : BaseService<NotaFiscalSaidaObservacao>, INotaFiscalSaidaObservacaoService
    {
        private readonly INotaFiscalSaidaObservacaoRepository _NotaFiscalSaidaObservacaoRepository;

        public NotaFiscalSaidaObservacaoService(INotaFiscalSaidaObservacaoRepository NotaFiscalSaidaObservacaoRepository,
                                 INotifier notificador) : base(notificador, NotaFiscalSaidaObservacaoRepository)
        {
            _NotaFiscalSaidaObservacaoRepository = NotaFiscalSaidaObservacaoRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaObservacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalSaidaObservacaoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalSaidaObservacaoRepository?.Dispose();
        }

        public Task Adicionar(NotaFiscalSaidaObservacao NotaFiscalSaidaObservacao)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(NotaFiscalSaidaObservacao NotaFiscalSaidaObservacao)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
