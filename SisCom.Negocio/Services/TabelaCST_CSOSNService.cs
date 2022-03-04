using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaCST_CSOSNService : BaseService<TabelaCST_CSOSN>, ITabelaCST_CSOSNService
    {
        private readonly ITabelaCST_CSOSNRepository _TabelaCST_CSOSNRepository;

        public TabelaCST_CSOSNService(ITabelaCST_CSOSNRepository TabelaCST_CSOSNRepository,
                                 INotifier notificador) : base(notificador, TabelaCST_CSOSNRepository)
        {
            _TabelaCST_CSOSNRepository = TabelaCST_CSOSNRepository;
        }

        public Task<IPagedList<TabelaCST_CSOSN>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaCST_CSOSNRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaCST_CSOSNRepository?.Dispose();
        }

        public Task Adicionar(TabelaCST_CSOSN TabelaCST_CSOSN)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCST_CSOSN TabelaCST_CSOSN)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
