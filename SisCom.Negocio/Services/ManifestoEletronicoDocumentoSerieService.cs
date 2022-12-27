using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class ManifestoEletronicoDocumentoSerieService : BaseService<ManifestoEletronicoDocumentoSerie>, IManifestoEletronicoDocumentoSerieService
    {
        private readonly IManifestoEletronicoDocumentoSerieRepository _manifestoEletronicoDocumentoSerieRepository;

        public ManifestoEletronicoDocumentoSerieService(IManifestoEletronicoDocumentoSerieRepository ManifestoEletronicoDocumentoSerieRepository,
                                                        INotifier notificador) : base(notificador, ManifestoEletronicoDocumentoSerieRepository)
        {
            _manifestoEletronicoDocumentoSerieRepository = ManifestoEletronicoDocumentoSerieRepository;
        }

        public Task<IPagedList<ManifestoEletronicoDocumentoSerie>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _manifestoEletronicoDocumentoSerieRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _manifestoEletronicoDocumentoSerieRepository?.Dispose();
        }

        public async Task Adicionar(ManifestoEletronicoDocumentoSerie ManifestoEletronicoDocumentoSerie)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _manifestoEletronicoDocumentoSerieRepository.Insert(ManifestoEletronicoDocumentoSerie);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(ManifestoEletronicoDocumentoSerie ManifestoEletronicoDocumentoSerie)
        {
            try
            {
                await _manifestoEletronicoDocumentoSerieRepository.Update(ManifestoEletronicoDocumentoSerie);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _manifestoEletronicoDocumentoSerieRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

    }
}
