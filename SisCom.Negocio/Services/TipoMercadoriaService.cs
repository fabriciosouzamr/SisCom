using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TipoMercadoriaService : BaseService<TipoMercadoria>, ITipoMercadoriaService
    {
        private readonly ITipoMercadoriaRepository _TipoMercadoriaRepository;

        public TipoMercadoriaService(ITipoMercadoriaRepository TipoMercadoriaRepository,
                                 INotifier notificador) : base(notificador, TipoMercadoriaRepository)
        {
            _TipoMercadoriaRepository = TipoMercadoriaRepository;
        }

        public Task<IPagedList<TipoMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TipoMercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TipoMercadoriaRepository?.Dispose();
        }

        public Task Adicionar(TipoMercadoria TipoMercadoria)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TipoMercadoria TipoMercadoria)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
