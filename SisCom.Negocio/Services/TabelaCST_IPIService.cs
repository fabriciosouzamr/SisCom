using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaCST_IPIService : BaseService<TabelaCST_IPI>, ITabelaCST_IPIService
    {
        private readonly ITabelaCST_IPIRepository _TabelaCST_IPIRepository;

        public TabelaCST_IPIService(ITabelaCST_IPIRepository TabelaCST_IPIRepository,
                                 INotifier notificador) : base(notificador, TabelaCST_IPIRepository)
        {
            _TabelaCST_IPIRepository = TabelaCST_IPIRepository;
        }

        public Task<IPagedList<TabelaCST_IPI>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaCST_IPIRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaCST_IPIRepository?.Dispose();
        }

        public Task Adicionar(TabelaCST_IPI TabelaCST_IPI)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCST_IPI TabelaCST_IPI)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
