using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaSpedTipoItemService : BaseService<TabelaSpedTipoItem>, ITabelaSpedTipoItemService
    {
        private readonly ITabelaSpedTipoItemRepository _TabelaSpedTipoItemRepository;

        public TabelaSpedTipoItemService(ITabelaSpedTipoItemRepository TabelaSpedTipoItemRepository,
                                 INotifier notificador) : base(notificador, TabelaSpedTipoItemRepository)
        {
            _TabelaSpedTipoItemRepository = TabelaSpedTipoItemRepository;
        }

        public Task<IPagedList<TabelaSpedTipoItem>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaSpedTipoItemRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaSpedTipoItemRepository?.Dispose();
        }

        public Task Adicionar(TabelaSpedTipoItem TabelaSpedTipoItem)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaSpedTipoItem TabelaSpedTipoItem)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
