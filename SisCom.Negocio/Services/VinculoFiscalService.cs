using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class VinculoFiscalService : BaseService<VinculoFiscal>, IVinculoFiscalService
    {
        private readonly IVinculoFiscalRepository _VinculoFiscalRepository;

        public VinculoFiscalService(IVinculoFiscalRepository VinculoFiscalRepository,
                                 INotifier notificador) : base(notificador, VinculoFiscalRepository)
        {
            _VinculoFiscalRepository = VinculoFiscalRepository;
        }

        public Task<IPagedList<VinculoFiscal>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _VinculoFiscalRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _VinculoFiscalRepository?.Dispose();
        }

        public Task Adicionar(VinculoFiscal VinculoFiscal)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(VinculoFiscal VinculoFiscal)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
