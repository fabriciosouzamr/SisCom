using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class ManifestoEletronicoDocumentoNotaService : BaseService<ManifestoEletronicoDocumentoNota>, IManifestoEletronicoDocumentoNotaService
    {
        private readonly IManifestoEletronicoDocumentoNotaRepository _ManifestoEletronicoDocumentoNotaRepository;

        public ManifestoEletronicoDocumentoNotaService(IManifestoEletronicoDocumentoNotaRepository ManifestoEletronicoDocumentoNotaRepository,
                                                   INotifier notificador) : base(notificador, ManifestoEletronicoDocumentoNotaRepository)
        {
            _ManifestoEletronicoDocumentoNotaRepository = ManifestoEletronicoDocumentoNotaRepository;
        }

        public Task<IPagedList<ManifestoEletronicoDocumentoNota>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _ManifestoEletronicoDocumentoNotaRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _ManifestoEletronicoDocumentoNotaRepository?.Dispose();
        }

        public async Task Adicionar(ManifestoEletronicoDocumentoNota ManifestoEletronicoDocumentoNota)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _ManifestoEletronicoDocumentoNotaRepository.Insert(ManifestoEletronicoDocumentoNota);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(ManifestoEletronicoDocumentoNota ManifestoEletronicoDocumentoNota)
        {
            try
            {
                await _ManifestoEletronicoDocumentoNotaRepository.Update(ManifestoEletronicoDocumentoNota);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _ManifestoEletronicoDocumentoNotaRepository.Delete(id);
        }

    }
}
