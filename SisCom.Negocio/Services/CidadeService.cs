using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _CidadeRepository;

        public CidadeService(ICidadeRepository CidadeRepository,
                                 INotifier notificador) : base(notificador, CidadeRepository)
        {
            _CidadeRepository = CidadeRepository;
        }

        public Task<IPagedList<Cidade>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _CidadeRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _CidadeRepository?.Dispose();
        }

        public Task Adicionar(Cidade Cidade)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Cidade Cidade)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
