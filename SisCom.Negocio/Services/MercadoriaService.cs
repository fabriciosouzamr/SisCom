using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class MercadoriaService : BaseService<Mercadoria>, IMercadoriaService
    {
        private readonly IMercadoriaRepository _MercadoriaRepository;

        public MercadoriaService(IMercadoriaRepository MercadoriaRepository,
                                 INotifier notificador) : base(notificador, MercadoriaRepository)
        {
            _MercadoriaRepository = MercadoriaRepository;
        }

        public Task<IPagedList<Mercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _MercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _MercadoriaRepository?.Dispose();
        }

        public Task Adicionar(Mercadoria Mercadoria)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Mercadoria Mercadoria)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
