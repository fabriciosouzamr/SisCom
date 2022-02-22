using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _EstadoRepository;

        public EstadoService(IEstadoRepository EstadoRepository,
                                 INotifier notificador) : base(notificador, EstadoRepository)
        {
            _EstadoRepository = EstadoRepository;
        }

        public Task<IPagedList<Estado>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _EstadoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _EstadoRepository?.Dispose();
        }

        public Task Adicionar(Estado Estado)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Estado Estado)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
