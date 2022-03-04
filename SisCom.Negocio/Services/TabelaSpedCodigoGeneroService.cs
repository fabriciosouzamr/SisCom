using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaSpedCodigoGeneroService : BaseService<TabelaSpedCodigoGenero>, ITabelaSpedCodigoGeneroService
    {
        private readonly ITabelaSpedCodigoGeneroRepository _TabelaSpedCodigoGeneroRepository;

        public TabelaSpedCodigoGeneroService(ITabelaSpedCodigoGeneroRepository TabelaSpedCodigoGeneroRepository,
                                 INotifier notificador) : base(notificador, TabelaSpedCodigoGeneroRepository)
        {
            _TabelaSpedCodigoGeneroRepository = TabelaSpedCodigoGeneroRepository;
        }

        public Task<IPagedList<TabelaSpedCodigoGenero>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaSpedCodigoGeneroRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaSpedCodigoGeneroRepository?.Dispose();
        }

        public Task Adicionar(TabelaSpedCodigoGenero TabelaSpedCodigoGenero)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaSpedCodigoGenero TabelaSpedCodigoGenero)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
