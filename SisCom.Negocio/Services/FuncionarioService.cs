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
    public class FuncionarioService : BaseService<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _FuncionarioRepository;

        public FuncionarioService(IFuncionarioRepository FuncionarioRepository,
                                 INotifier notificador) : base(notificador, FuncionarioRepository)
        {
            _FuncionarioRepository = FuncionarioRepository;
        }

        public Task<IPagedList<Funcionario>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _FuncionarioRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _FuncionarioRepository?.Dispose();
        }

        public async Task Adicionar(Funcionario Funcionario)
        {
            await _FuncionarioRepository.Insert(Funcionario);
        }

        public Task Atualizar(Funcionario Funcionario)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IFuncionarioService.Adicionar(Funcionario Funcionario)
        {
            throw new NotImplementedException();
        }

        Task IFuncionarioService.Atualizar(Funcionario Funcionario)
        {
            throw new NotImplementedException();
        }

        Task IFuncionarioService.Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<Funcionario>> IFuncionarioService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Funcionario> IFuncionarioService.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IPagedList<Funcionario>> IFuncionarioService.GetPagedList(FilteredPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
