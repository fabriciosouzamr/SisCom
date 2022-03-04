using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class TipoClienteService : BaseService<TipoCliente>, ITipoClienteService
    {
        private readonly ITipoClienteRepository _TipoClienteRepository;

        public TipoClienteService(ITipoClienteRepository TipoClienteRepository,
                                 INotifier notificador) : base(notificador, TipoClienteRepository)
        {
            _TipoClienteRepository = TipoClienteRepository;
        }

        public Task<IPagedList<TipoCliente>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _TipoClienteRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _TipoClienteRepository?.Dispose();
        }

        public async Task Adicionar(TipoCliente TipoCliente)
        {
            await _TipoClienteRepository.Insert(TipoCliente);
        }

        public Task Atualizar(TipoCliente TipoCliente)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        Task ITipoClienteService.Adicionar(TipoCliente TipoCliente)
        {
            throw new NotImplementedException();
        }

        Task ITipoClienteService.Atualizar(TipoCliente TipoCliente)
        {
            throw new NotImplementedException();
        }

        Task ITipoClienteService.Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<TipoCliente>> ITipoClienteService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<TipoCliente> ITipoClienteService.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IPagedList<TipoCliente>> ITipoClienteService.GetPagedList(FilteredPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
