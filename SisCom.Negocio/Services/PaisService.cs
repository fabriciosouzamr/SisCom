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
    public class PaisService : BaseService<Pais>, IPaisService
    {
        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository _paisRepository,
                           INotifier notificador) : base(notificador, _paisRepository)
        {
            this._paisRepository = _paisRepository;
        }

        public Task<IPagedList<Pais>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _paisRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _paisRepository?.Dispose();
        }
        public virtual async Task Adicionar(Pais Pais)
        {
            try
            {
                var empresa = await _paisRepository.Search(f => f.Nome == Pais.Nome);

                if (empresa.Count() != 0)
                {
                    Notify("Já existe um país com este nome informado.");
                    return;
                }

                await _paisRepository.Insert(Pais);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public virtual async Task Atualizar(Pais Pais)
        {
            try
            {
                var exists = _paisRepository.Exists(f => (f.Nome == Pais.Nome) && (f.Id != Pais.Id));

                if (exists)
                {
                    Notify("Já existe um país com este nome informado.");
                    return;
                }

                await _paisRepository.Update(Pais);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public async Task Excluir(Guid id)
        {
            await _paisRepository.Delete(id);
        }

        public Task<List<Pais>> Combo()
        {
            throw new NotImplementedException();
        }
    }
}
