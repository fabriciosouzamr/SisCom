using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TabelaBeneficioSPEDService : BaseService<TabelaBeneficioSPED>, ITabelaBeneficioSPEDService
    {
        private readonly ITabelaBeneficioSPEDRepository _TabelaBeneficioSPEDRepository;

        public TabelaBeneficioSPEDService(ITabelaBeneficioSPEDRepository TabelaBeneficioSPEDRepository,
                                 INotifier notificador) : base(notificador, TabelaBeneficioSPEDRepository)
        {
            _TabelaBeneficioSPEDRepository = TabelaBeneficioSPEDRepository;
        }

        public Task<IPagedList<TabelaBeneficioSPED>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TabelaBeneficioSPEDRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TabelaBeneficioSPEDRepository?.Dispose();
        }

        public Task Adicionar(TabelaBeneficioSPED TabelaBeneficioSPED)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TabelaBeneficioSPED TabelaBeneficioSPED)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
