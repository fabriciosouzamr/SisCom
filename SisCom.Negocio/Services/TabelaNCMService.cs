using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaNCMService : BaseService<TabelaNCM>, ITabelaNCMService
    {
        private readonly ITabelaNCMRepository _TabelaNCMRepository;

        public TabelaNCMService(ITabelaNCMRepository TabelaNCMRepository,
                                 INotifier notificador) : base(notificador, TabelaNCMRepository)
        {
            _TabelaNCMRepository = TabelaNCMRepository;
        }

        public Task<IPagedList<TabelaNCM>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaNCMRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaNCMRepository?.Dispose();
        }

        public Task Adicionar(TabelaNCM TabelaNCM)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaNCM TabelaNCM)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
