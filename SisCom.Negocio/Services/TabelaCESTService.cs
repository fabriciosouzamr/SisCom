using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaCESTService : BaseService<TabelaCEST>, ITabelaCESTService
    {
        private readonly ITabelaCESTRepository _TabelaCESTRepository;

        public TabelaCESTService(ITabelaCESTRepository TabelaCESTRepository,
                                 INotifier notificador) : base(notificador, TabelaCESTRepository)
        {
            _TabelaCESTRepository = TabelaCESTRepository;
        }

        public Task<IPagedList<TabelaCEST>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaCESTRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaCESTRepository?.Dispose();
        }

        public Task Adicionar(TabelaCEST TabelaCEST)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCEST TabelaCEST)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
