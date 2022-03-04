using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class GrupoNaturezaReceita_CTS_PIS_COFINSService : BaseService<GrupoNaturezaReceita_CTS_PIS_COFINS>, IGrupoNaturezaReceita_CTS_PIS_COFINSService
    {
        private readonly IGrupoNaturezaReceita_CTS_PIS_COFINSRepository _GrupoNaturezaReceita_CTS_PIS_COFINSRepository;

        public GrupoNaturezaReceita_CTS_PIS_COFINSService(IGrupoNaturezaReceita_CTS_PIS_COFINSRepository GrupoNaturezaReceita_CTS_PIS_COFINSRepository,
                                 INotifier notificador) : base(notificador, GrupoNaturezaReceita_CTS_PIS_COFINSRepository)
        {
            _GrupoNaturezaReceita_CTS_PIS_COFINSRepository = GrupoNaturezaReceita_CTS_PIS_COFINSRepository;
        }

        public Task<IPagedList<GrupoNaturezaReceita_CTS_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _GrupoNaturezaReceita_CTS_PIS_COFINSRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _GrupoNaturezaReceita_CTS_PIS_COFINSRepository?.Dispose();
        }

        public Task Adicionar(GrupoNaturezaReceita_CTS_PIS_COFINS GrupoNaturezaReceita_CTS_PIS_COFINS)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(GrupoNaturezaReceita_CTS_PIS_COFINS GrupoNaturezaReceita_CTS_PIS_COFINS)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
