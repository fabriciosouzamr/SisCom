using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class FiscalEstadoIcmsService : BaseService<FiscalEstadoIcms>, IFiscalEstadoIcmsService
    {
        private readonly IFiscalEstadoIcmsRepository fiscalEstadoIcmsRepository;

        public FiscalEstadoIcmsService(IFiscalEstadoIcmsRepository FiscalEstadoIcmsRepository,
                                       INotifier notificador) : base(notificador, FiscalEstadoIcmsRepository)
        {
            this.fiscalEstadoIcmsRepository = FiscalEstadoIcmsRepository;
        }

        public async Task Adicionar(FiscalEstadoIcms FiscalEstadoIcms)
        {
            try
            {
                await fiscalEstadoIcmsRepository.Insert(FiscalEstadoIcms);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(FiscalEstadoIcms FiscalEstadoIcms)
        {
            try
            {
                await fiscalEstadoIcmsRepository.Update(FiscalEstadoIcms);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            await fiscalEstadoIcmsRepository.Delete(id);

            Notify("Exclusão Efetuada.");

            return true;
        }

        public override void Dispose()
        {
            fiscalEstadoIcmsRepository?.Dispose();
        }
    }
}
