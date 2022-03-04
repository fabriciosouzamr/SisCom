using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaClasseEnquadramentoIPIService : BaseService<TabelaClasseEnquadramentoIPI>, ITabelaClasseEnquadramentoIPIService
    {
        private readonly ITabelaClasseEnquadramentoIPIRepository _TabelaClasseEnquadramentoIPIRepository;

        public TabelaClasseEnquadramentoIPIService(ITabelaClasseEnquadramentoIPIRepository TabelaClasseEnquadramentoIPIRepository,
                                 INotifier notificador) : base(notificador, TabelaClasseEnquadramentoIPIRepository)
        {
            _TabelaClasseEnquadramentoIPIRepository = TabelaClasseEnquadramentoIPIRepository;
        }

        public Task<IPagedList<TabelaClasseEnquadramentoIPI>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaClasseEnquadramentoIPIRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaClasseEnquadramentoIPIRepository?.Dispose();
        }

        public Task Adicionar(TabelaClasseEnquadramentoIPI TabelaClasseEnquadramentoIPI)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaClasseEnquadramentoIPI TabelaClasseEnquadramentoIPI)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
