using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalEntradaMercadoriaService : BaseService<NotaFiscalEntradaMercadoria>, INotaFiscalEntradaMercadoriaService
    {
        private readonly INotaFiscalEntradaMercadoriaRepository _NotaFiscalEntradaMercadoriaRepository;

        public NotaFiscalEntradaMercadoriaService(INotaFiscalEntradaMercadoriaRepository NotaFiscalEntradaMercadoriaRepository,
                                     INotifier notificador) : base(notificador, NotaFiscalEntradaMercadoriaRepository)
        {
            _NotaFiscalEntradaMercadoriaRepository = NotaFiscalEntradaMercadoriaRepository;
        }

        public Task<IPagedList<NotaFiscalEntradaMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalEntradaMercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalEntradaMercadoriaRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalEntradaMercadoria NotaFiscalEntradaMercadoria)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _NotaFiscalEntradaMercadoriaRepository.Insert(NotaFiscalEntradaMercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalEntradaMercadoria NotaFiscalEntradaMercadoria)
        {
            try
            {
                await _NotaFiscalEntradaMercadoriaRepository.Update(NotaFiscalEntradaMercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _NotaFiscalEntradaMercadoriaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public async Task ExcluirTodas(Guid id)
        {
            await _NotaFiscalEntradaMercadoriaRepository.Delete(w => w.NotaFiscalEntradaId == id);

            Notify("Exclusão Efetuada.");
        }

    }
}
