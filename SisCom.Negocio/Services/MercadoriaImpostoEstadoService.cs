using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class MercadoriaImpostoEstadoService : BaseService<MercadoriaImpostoEstado>, IMercadoriaImpostoEstadoService
    {
        private readonly IMercadoriaImpostoEstadoRepository _MercadoriaImpostoEstadoRepository;

        public MercadoriaImpostoEstadoService(IMercadoriaImpostoEstadoRepository MercadoriaImpostoEstadoRepository,
                                              INotifier notificador) : base(notificador, MercadoriaImpostoEstadoRepository)
        {
            _MercadoriaImpostoEstadoRepository = MercadoriaImpostoEstadoRepository;
        }

        public Task<IPagedList<MercadoriaImpostoEstado>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _MercadoriaImpostoEstadoRepository.GetPagedList(f =>
            (
                parameters.Search == null /*|| f..Contains(parameters.Search)*/
            ), parameters);
        }

        public override void Dispose()
        {
            _MercadoriaImpostoEstadoRepository?.Dispose();
        }

        public Task Adicionar(MercadoriaImpostoEstado MercadoriaImpostoEstado)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(MercadoriaImpostoEstado MercadoriaImpostoEstado)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
