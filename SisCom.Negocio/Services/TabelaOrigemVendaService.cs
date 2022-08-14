using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaOrigemVendaService : BaseService<TabelaOrigemVenda>, ITabelaOrigemVendaService
    {
        private readonly ITabelaOrigemVendaRepository _TabelaOrigemVendaRepository;

        public TabelaOrigemVendaService(ITabelaOrigemVendaRepository TabelaOrigemVendaRepository,
                                        INotifier notificador) : base(notificador, TabelaOrigemVendaRepository)
        {
            _TabelaOrigemVendaRepository = TabelaOrigemVendaRepository;
        }

        public Task<IPagedList<TabelaOrigemVenda>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaOrigemVendaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaOrigemVendaRepository?.Dispose();
        }

        public Task Adicionar(TabelaOrigemVenda TabelaOrigemVenda)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaOrigemVenda TabelaOrigemVenda)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
