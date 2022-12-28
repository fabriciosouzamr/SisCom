using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class VeiculoPlacaService : BaseService<VeiculoPlaca>, IVeiculoPlacaService
    {
        private readonly IVeiculoPlacaRepository _VeiculoPlacaRepository;

        public VeiculoPlacaService(IVeiculoPlacaRepository VeiculoPlacaRepository,
                                   INotifier notificador) : base(notificador, VeiculoPlacaRepository)
        {
            _VeiculoPlacaRepository = VeiculoPlacaRepository;
        }

        public Task<IPagedList<VeiculoPlaca>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _VeiculoPlacaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.NumeroPlaca.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _VeiculoPlacaRepository?.Dispose();
        }

        public Task Adicionar(VeiculoPlaca VeiculoPlaca)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(VeiculoPlaca VeiculoPlaca)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
