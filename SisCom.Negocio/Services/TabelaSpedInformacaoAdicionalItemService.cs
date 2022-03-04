using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaSpedInformacaoAdicionalItemService : BaseService<TabelaSpedInformacaoAdicionalItem>, ITabelaSpedInformacaoAdicionalItemService
    {
        private readonly ITabelaSpedInformacaoAdicionalItemRepository _TabelaSpedInformacaoAdicionalItemRepository;

        public TabelaSpedInformacaoAdicionalItemService(ITabelaSpedInformacaoAdicionalItemRepository TabelaSpedInformacaoAdicionalItemRepository,
                                 INotifier notificador) : base(notificador, TabelaSpedInformacaoAdicionalItemRepository)
        {
            _TabelaSpedInformacaoAdicionalItemRepository = TabelaSpedInformacaoAdicionalItemRepository;
        }

        public Task<IPagedList<TabelaSpedInformacaoAdicionalItem>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaSpedInformacaoAdicionalItemRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaSpedInformacaoAdicionalItemRepository?.Dispose();
        }

        public Task Adicionar(TabelaSpedInformacaoAdicionalItem TabelaSpedInformacaoAdicionalItem)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaSpedInformacaoAdicionalItem TabelaSpedInformacaoAdicionalItem)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
