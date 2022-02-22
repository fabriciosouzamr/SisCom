using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class CFOPService : BaseService<TabelaCFOP>, ICFOPService
    {
        private readonly ICFOPRepository _CFOPRepository;

        public CFOPService(ICFOPRepository CFOPRepository,
                           INotifier notificador) : base(notificador, CFOPRepository)
        {
            _CFOPRepository = CFOPRepository;
        }

        public Task<IPagedList<TabelaCFOP>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _CFOPRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _CFOPRepository?.Dispose();
        }

        public Task Adicionar(TabelaCFOP CFOP)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaCFOP CFOP)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TabelaCFOP>> Combo()
        {
            throw new NotImplementedException();
        }
    }
}
