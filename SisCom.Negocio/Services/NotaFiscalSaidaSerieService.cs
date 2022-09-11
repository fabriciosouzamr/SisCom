using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaSerieService : BaseService<NotaFiscalSaidaSerie>, INotaFiscalSaidaSerieService
    {
        private readonly INotaFiscalSaidaSerieRepository _NotaFiscalSaidaSerieRepository;

        public NotaFiscalSaidaSerieService(INotaFiscalSaidaSerieRepository NotaFiscalSaidaSerieRepository,
                                                INotifier notificador) : base(notificador, NotaFiscalSaidaSerieRepository)
        {
            _NotaFiscalSaidaSerieRepository = NotaFiscalSaidaSerieRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaSerie>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NotaFiscalSaidaSerieRepository.GetPagedList(f =>
            (
                parameters.Search == null
            ), parameters);
        }

        public override void Dispose()
        {
            _NotaFiscalSaidaSerieRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaidaSerie NotaFiscalSaidaSerie)
        {
            //if (!RunValidation(new PessoaValidation(), pessoa)) return;

            try
            {
                await _NotaFiscalSaidaSerieRepository.Insert(NotaFiscalSaidaSerie);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaidaSerie NotaFiscalSaidaSerie)
        {
            try
            {
                await _NotaFiscalSaidaSerieRepository.Update(NotaFiscalSaidaSerie);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _NotaFiscalSaidaSerieRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

    }
}
