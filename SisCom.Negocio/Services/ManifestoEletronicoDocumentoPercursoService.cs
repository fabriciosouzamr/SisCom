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
    public class ManifestoEletronicoDocumentoPercursoService : BaseService<ManifestoEletronicoDocumentoPercurso>, IManifestoEletronicoDocumentoPercursoService
    {
        private readonly IManifestoEletronicoDocumentoPercursoRepository _ManifestoEletronicoDocumentoPercursoRepository;

        public ManifestoEletronicoDocumentoPercursoService(IManifestoEletronicoDocumentoPercursoRepository ManifestoEletronicoDocumentoPercursoRepository,
                                                   INotifier notificador) : base(notificador, ManifestoEletronicoDocumentoPercursoRepository)
        {
            _ManifestoEletronicoDocumentoPercursoRepository = ManifestoEletronicoDocumentoPercursoRepository;
        }

        public Task<IPagedList<ManifestoEletronicoDocumentoPercurso>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _ManifestoEletronicoDocumentoPercursoRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _ManifestoEletronicoDocumentoPercursoRepository?.Dispose();
        }

        public async Task Adicionar(ManifestoEletronicoDocumentoPercurso ManifestoEletronicoDocumentoPercurso)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _ManifestoEletronicoDocumentoPercursoRepository.Insert(ManifestoEletronicoDocumentoPercurso);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(ManifestoEletronicoDocumentoPercurso ManifestoEletronicoDocumentoPercurso)
        {
            try
            {
                await _ManifestoEletronicoDocumentoPercursoRepository.Update(ManifestoEletronicoDocumentoPercurso);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _ManifestoEletronicoDocumentoPercursoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

    }
}
