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

        public async Task Adicionar(Funcionario funcionario)
        {
            try
            {
                var _pessoa = await _FuncionarioRepository.Search(f => f.Nome == funcionario.Nome);

                if (_pessoa.Count() != 0)
                {
                    Notify("Já existe um funcionário com este nome informado.");
                    return;
                }

                await _FuncionarioRepository.Insert(funcionario);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(Funcionario funcionario)
        {
            try
            {
                var exists = _FuncionarioRepository.Exists(f => f.Nome == funcionario.Nome && f.Id != funcionario.Id);

                if (exists)
                {
                    Notify("Já existe um funcionário com este nome informado.");
                    return;
                }

                await _FuncionarioRepository.Update(funcionario);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _FuncionarioRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }
    }
}
