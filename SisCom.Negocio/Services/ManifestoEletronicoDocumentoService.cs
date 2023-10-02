using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class ManifestoEletronicoDocumentoService : BaseService<ManifestoEletronicoDocumento>, IManifestoEletronicoDocumentoService
    {
        private readonly IManifestoEletronicoDocumentoRepository _ManifestoEletronicoDocumentoRepository;

        public ManifestoEletronicoDocumentoService(IManifestoEletronicoDocumentoRepository ManifestoEletronicoDocumentoRepository,
                                                   INotifier notificador) : base(notificador, ManifestoEletronicoDocumentoRepository)
        {
            _ManifestoEletronicoDocumentoRepository = ManifestoEletronicoDocumentoRepository;
        }

        public Task<IPagedList<ManifestoEletronicoDocumento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _ManifestoEletronicoDocumentoRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _ManifestoEletronicoDocumentoRepository?.Dispose();
        }

        public async Task Adicionar(ManifestoEletronicoDocumento ManifestoEletronicoDocumento)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _ManifestoEletronicoDocumentoRepository.Insert(ManifestoEletronicoDocumento);
            }
            catch (Exception Ex)
            {
                if (Ex.InnerException == null)
                { Notify("ERRO: " + Ex.Message + "."); }
                else
                { Notify("ERRO: " + $"{Ex.Message.ToString()} - {Ex.InnerException.Message.ToString()}"); }
                
            }
        }

        public async Task Atualizar(ManifestoEletronicoDocumento ManifestoEletronicoDocumento)
        {
            try
            {
                await _ManifestoEletronicoDocumentoRepository.Update(ManifestoEletronicoDocumento);
            }
            catch (Exception Ex)
            {
                Notify("ManifestoEletronicoDocumentoService", Ex);
            }
        }

        public async Task Excluir(Guid id)
        {
            await _ManifestoEletronicoDocumentoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

    }
}
