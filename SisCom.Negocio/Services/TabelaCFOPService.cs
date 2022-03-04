using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaCFOPService : BaseService<TabelaCFOP>, ITabelaCFOPService
    {
        private readonly ITabelaCFOPRepository _TabelaCFOPRepository;

        public TabelaCFOPService(ITabelaCFOPRepository TabelaCFOPRepository,
                                 INotifier notificador) : base(notificador, TabelaCFOPRepository)
        {
            _TabelaCFOPRepository = TabelaCFOPRepository;
        }

        public Task<IPagedList<TabelaCFOP>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaCFOPRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaCFOPRepository?.Dispose();
        }

        public Task Adicionar(TabelaCFOP TabelaCFOP)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCFOP TabelaCFOP)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
