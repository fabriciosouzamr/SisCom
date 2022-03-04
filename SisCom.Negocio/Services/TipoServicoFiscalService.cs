using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TipoServicoFiscalService : BaseService<TipoServicoFiscal>, ITipoServicoFiscalService
    {
        private readonly ITipoServicoFiscalRepository _TipoServicoFiscalRepository;

        public TipoServicoFiscalService(ITipoServicoFiscalRepository TipoServicoFiscalRepository,
                                 INotifier notificador) : base(notificador, TipoServicoFiscalRepository)
        {
            _TipoServicoFiscalRepository = TipoServicoFiscalRepository;
        }

        public Task<IPagedList<TipoServicoFiscal>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TipoServicoFiscalRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TipoServicoFiscalRepository?.Dispose();
        }

        public Task Adicionar(TipoServicoFiscal TipoServicoFiscal)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TipoServicoFiscal TipoServicoFiscal)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
