using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NotaFiscalSaidaObservacaoService : BaseService<NotaFiscalSaidaObservacao>, INotaFiscalSaidaObservacaoService
    {
        private readonly INotaFiscalSaidaObservacaoRepository _notaFiscalSaidaObservacaoRepository;

        public NotaFiscalSaidaObservacaoService(INotaFiscalSaidaObservacaoRepository NotaFiscalSaidaObservacaoRepository,
                                 INotifier notificador) : base(notificador, NotaFiscalSaidaObservacaoRepository)
        {
            _notaFiscalSaidaObservacaoRepository = NotaFiscalSaidaObservacaoRepository;
        }

        public Task<IPagedList<NotaFiscalSaidaObservacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _notaFiscalSaidaObservacaoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _notaFiscalSaidaObservacaoRepository?.Dispose();
        }

        public async Task Adicionar(NotaFiscalSaidaObservacao notaFiscalSaidaObservacao)
        {
            try
            {
                await _notaFiscalSaidaObservacaoRepository.Insert(notaFiscalSaidaObservacao);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NotaFiscalSaidaObservacao notaFiscalSaidaObservacao)
        {
            try
            {
                await _notaFiscalSaidaObservacaoRepository.Update(notaFiscalSaidaObservacao);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _notaFiscalSaidaObservacaoRepository.Delete(id);
        }
    }
}
