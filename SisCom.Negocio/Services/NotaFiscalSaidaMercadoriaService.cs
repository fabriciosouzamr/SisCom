using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaMercadoriaService : BaseService<NotaFiscalSaidaMercadoria>, INotaFiscalSaidaMercadoriaService
    {
        private readonly INotaFiscalSaidaMercadoriaRepository _NotaFiscalSaidaMercadoriaRepository;

        public NotaFiscalSaidaMercadoriaService(INotaFiscalSaidaMercadoriaRepository NotaFiscalSaidaMercadoriaRepository,
                                     INotifier notificador) : base(notificador, NotaFiscalSaidaMercadoriaRepository)
        {
            _NotaFiscalSaidaMercadoriaRepository = NotaFiscalSaidaMercadoriaRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalSaidaMercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalSaidaMercadoriaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaidaMercadoria NotaFiscalSaidaMercadoria)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _NotaFiscalSaidaMercadoriaRepository.Insert(NotaFiscalSaidaMercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaidaMercadoria NotaFiscalSaidaMercadoria)
        {
            try
            {
                await _NotaFiscalSaidaMercadoriaRepository.Update(NotaFiscalSaidaMercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _NotaFiscalSaidaMercadoriaRepository.Delete(id);
        }

    }
}
