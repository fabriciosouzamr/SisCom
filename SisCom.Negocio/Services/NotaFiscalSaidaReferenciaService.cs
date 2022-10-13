using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaReferenciaService : BaseService<NotaFiscalSaidaReferencia>, INotaFiscalSaidaReferenciaService
    {
        private readonly INotaFiscalSaidaReferenciaRepository _notaFiscalSaidaReferenciaRepository;

        public NotaFiscalSaidaReferenciaService(INotaFiscalSaidaReferenciaRepository NotaFiscalSaidaReferenciaRepository,
                                 INotifier notificador) : base(notificador, NotaFiscalSaidaReferenciaRepository)
        {
            _notaFiscalSaidaReferenciaRepository = NotaFiscalSaidaReferenciaRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaReferencia>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _notaFiscalSaidaReferenciaRepository.GetPagedList(f =>
            (
                parameters.Search == null /*|| f.Descricao.Contains(parameters.Search)*/
            ), parameters);
        }

        public override void Dispose()
        {
            _notaFiscalSaidaReferenciaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaidaReferencia NotaFiscalSaidaReferencia)
        {
            try
            {
                await _notaFiscalSaidaReferenciaRepository.Insert(NotaFiscalSaidaReferencia);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaidaReferencia NotaFiscalSaidaReferencia)
        {
            try
            {
                await _notaFiscalSaidaReferenciaRepository.Update(NotaFiscalSaidaReferencia);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _notaFiscalSaidaReferenciaRepository.Delete(id);
        }
    }
}
