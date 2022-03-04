using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaANPService : BaseService<TabelaANP>, ITabelaANPService
    {
        private readonly ITabelaANPRepository _TabelaANPRepository;

        public TabelaANPService(ITabelaANPRepository TabelaANPRepository,
                                 INotifier notificador) : base(notificador, TabelaANPRepository)
        {
            _TabelaANPRepository = TabelaANPRepository;
        }

        public Task<IPagedList<TabelaANP>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaANPRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaANPRepository?.Dispose();
        }

        public Task Adicionar(TabelaANP TabelaANP)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaANP TabelaANP)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
