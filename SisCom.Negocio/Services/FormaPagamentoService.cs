using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class FormaPagamentoService : BaseService<FormaPagamento>, IFormaPagamentoService
    {
        private readonly IFormaPagamentoRepository _FormaPagamentoRepository;

        public FormaPagamentoService(IFormaPagamentoRepository FormaPagamentoRepository,
                                 INotifier notificador) : base(notificador, FormaPagamentoRepository)
        {
            _FormaPagamentoRepository = FormaPagamentoRepository;
        }

        public Task<IPagedList<FormaPagamento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _FormaPagamentoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _FormaPagamentoRepository?.Dispose();
        }

        public Task Adicionar(FormaPagamento FormaPagamento)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(FormaPagamento FormaPagamento)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
