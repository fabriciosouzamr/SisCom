using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaSituacaoTributariaNFCeService : BaseService<TabelaSituacaoTributariaNFCe>, ITabelaSituacaoTributariaNFCeService
    {
        private readonly ITabelaSituacaoTributariaNFCeRepository _TabelaSituacaoTributariaNFCeRepository;

        public TabelaSituacaoTributariaNFCeService(ITabelaSituacaoTributariaNFCeRepository TabelaSituacaoTributariaNFCeRepository,
                                 INotifier notificador) : base(notificador, TabelaSituacaoTributariaNFCeRepository)
        {
            _TabelaSituacaoTributariaNFCeRepository = TabelaSituacaoTributariaNFCeRepository;
        }

        public Task<IPagedList<TabelaSituacaoTributariaNFCe>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaSituacaoTributariaNFCeRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaSituacaoTributariaNFCeRepository?.Dispose();
        }

        public Task Adicionar(TabelaSituacaoTributariaNFCe TabelaSituacaoTributariaNFCe)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaSituacaoTributariaNFCe TabelaSituacaoTributariaNFCe)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
