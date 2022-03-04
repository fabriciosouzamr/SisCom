using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaCodigoEnquadramentoIPIService : BaseService<TabelaCodigoEnquadramentoIPI>, ITabelaCodigoEnquadramentoIPIService
    {
        private readonly ITabelaCodigoEnquadramentoIPIRepository _TabelaCodigoEnquadramentoIPIRepository;

        public TabelaCodigoEnquadramentoIPIService(ITabelaCodigoEnquadramentoIPIRepository TabelaCodigoEnquadramentoIPIRepository,
                                 INotifier notificador) : base(notificador, TabelaCodigoEnquadramentoIPIRepository)
        {
            _TabelaCodigoEnquadramentoIPIRepository = TabelaCodigoEnquadramentoIPIRepository;
        }

        public Task<IPagedList<TabelaCodigoEnquadramentoIPI>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaCodigoEnquadramentoIPIRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaCodigoEnquadramentoIPIRepository?.Dispose();
        }

        public Task Adicionar(TabelaCodigoEnquadramentoIPI TabelaCodigoEnquadramentoIPI)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCodigoEnquadramentoIPI TabelaCodigoEnquadramentoIPI)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
