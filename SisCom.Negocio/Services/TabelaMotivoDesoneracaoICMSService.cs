using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaMotivoDesoneracaoICMSService : BaseService<TabelaMotivoDesoneracaoICMS>, ITabelaMotivoDesoneracaoICMSService
    {
        private readonly ITabelaMotivoDesoneracaoICMSRepository _TabelaMotivoDesoneracaoICMSRepository;

        public TabelaMotivoDesoneracaoICMSService(ITabelaMotivoDesoneracaoICMSRepository TabelaMotivoDesoneracaoICMSRepository,
                                 INotifier notificador) : base(notificador, TabelaMotivoDesoneracaoICMSRepository)
        {
            _TabelaMotivoDesoneracaoICMSRepository = TabelaMotivoDesoneracaoICMSRepository;
        }

        public Task<IPagedList<TabelaMotivoDesoneracaoICMS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaMotivoDesoneracaoICMSRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaMotivoDesoneracaoICMSRepository?.Dispose();
        }

        public Task Adicionar(TabelaMotivoDesoneracaoICMS TabelaMotivoDesoneracaoICMS)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaMotivoDesoneracaoICMS TabelaMotivoDesoneracaoICMS)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
