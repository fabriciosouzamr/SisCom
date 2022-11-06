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

        public async Task Adicionar(MercadoriaImpostoEstado MercadoriaImpostoEstado)
        {
            try
            {
                await _MercadoriaImpostoEstadoRepository.Insert(MercadoriaImpostoEstado);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(MercadoriaImpostoEstado MercadoriaImpostoEstado)
        {
            try
            {
                await _MercadoriaImpostoEstadoRepository.Update(MercadoriaImpostoEstado);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
