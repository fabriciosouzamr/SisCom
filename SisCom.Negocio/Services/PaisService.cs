using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class PaisService : BaseService<Pais>, IPaisService
    {
        private readonly IPaisRepository _PaisRepository;

        public PaisService(IPaisRepository PaisRepository,
                                 INotifier notificador) : base(notificador, PaisRepository)
        {
            _PaisRepository = PaisRepository;
        }

        public Task<IPagedList<Pais>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _PaisRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _PaisRepository?.Dispose();
        }

        public Task Adicionar(Pais Pais)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Pais Pais)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
