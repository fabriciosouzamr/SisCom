using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaModalidadeDeterminacaoBCICMSService : BaseService<TabelaModalidadeDeterminacaoBCICMS>, ITabelaModalidadeDeterminacaoBCICMSService
    {
        private readonly ITabelaModalidadeDeterminacaoBCICMSRepository _TabelaModalidadeDeterminacaoBCICMSRepository;

        public TabelaModalidadeDeterminacaoBCICMSService(ITabelaModalidadeDeterminacaoBCICMSRepository TabelaModalidadeDeterminacaoBCICMSRepository,
                                 INotifier notificador) : base(notificador, TabelaModalidadeDeterminacaoBCICMSRepository)
        {
            _TabelaModalidadeDeterminacaoBCICMSRepository = TabelaModalidadeDeterminacaoBCICMSRepository;
        }

        public Task<IPagedList<TabelaModalidadeDeterminacaoBCICMS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaModalidadeDeterminacaoBCICMSRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaModalidadeDeterminacaoBCICMSRepository?.Dispose();
        }

        public Task Adicionar(TabelaModalidadeDeterminacaoBCICMS TabelaModalidadeDeterminacaoBCICMS)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaModalidadeDeterminacaoBCICMS TabelaModalidadeDeterminacaoBCICMS)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
