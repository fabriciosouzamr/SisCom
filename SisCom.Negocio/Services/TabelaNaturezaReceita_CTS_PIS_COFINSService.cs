using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaNaturezaReceita_CTS_PIS_COFINSService : BaseService<TabelaNaturezaReceita_CTS_PIS_COFINS>, ITabelaNaturezaReceita_CTS_PIS_COFINSService
    {
        private readonly ITabelaNaturezaReceita_CTS_PIS_COFINSRepository _TabelaNaturezaReceita_CTS_PIS_COFINSRepository;

        public TabelaNaturezaReceita_CTS_PIS_COFINSService(ITabelaNaturezaReceita_CTS_PIS_COFINSRepository TabelaNaturezaReceita_CTS_PIS_COFINSRepository,
                                 INotifier notificador) : base(notificador, TabelaNaturezaReceita_CTS_PIS_COFINSRepository)
        {
            _TabelaNaturezaReceita_CTS_PIS_COFINSRepository = TabelaNaturezaReceita_CTS_PIS_COFINSRepository;
        }

        public Task<IPagedList<TabelaNaturezaReceita_CTS_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaNaturezaReceita_CTS_PIS_COFINSRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaNaturezaReceita_CTS_PIS_COFINSRepository?.Dispose();
        }

        public Task Adicionar(TabelaNaturezaReceita_CTS_PIS_COFINS TabelaNaturezaReceita_CTS_PIS_COFINS)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaNaturezaReceita_CTS_PIS_COFINS TabelaNaturezaReceita_CTS_PIS_COFINS)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
