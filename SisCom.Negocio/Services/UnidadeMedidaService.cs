using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class UnidadeMedidaService : BaseService<UnidadeMedida>, IUnidadeMedidaService
    {
        private readonly IUnidadeMedidaRepository _UnidadeMedidaRepository;

        public UnidadeMedidaService(IUnidadeMedidaRepository UnidadeMedidaRepository,
                                 INotifier notificador) : base(notificador, UnidadeMedidaRepository)
        {
            _UnidadeMedidaRepository = UnidadeMedidaRepository;
        }

        public Task<IPagedList<UnidadeMedida>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _UnidadeMedidaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _UnidadeMedidaRepository?.Dispose();
        }

        public Task Adicionar(UnidadeMedida UnidadeMedida)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(UnidadeMedida UnidadeMedida)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
