using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaCST_PIS_COFINSService : BaseService<TabelaCST_PIS_COFINS>, ITabelaCST_PIS_COFINSService
    {
        private readonly ITabelaCST_PIS_COFINSRepository _TabelaCST_PIS_COFINSRepository;

        public TabelaCST_PIS_COFINSService(ITabelaCST_PIS_COFINSRepository TabelaCST_PIS_COFINSRepository,
                                 INotifier notificador) : base(notificador, TabelaCST_PIS_COFINSRepository)
        {
            _TabelaCST_PIS_COFINSRepository = TabelaCST_PIS_COFINSRepository;
        }

        public Task<IPagedList<TabelaCST_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaCST_PIS_COFINSRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaCST_PIS_COFINSRepository?.Dispose();
        }

        public Task Adicionar(TabelaCST_PIS_COFINS TabelaCST_PIS_COFINS)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCST_PIS_COFINS TabelaCST_PIS_COFINS)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
