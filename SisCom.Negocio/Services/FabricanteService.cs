using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class FabricanteService : BaseService<Fabricante>, IFabricanteService
    {
        private readonly IFabricanteRepository _FabricanteRepository;

        public FabricanteService(IFabricanteRepository FabricanteRepository,
                                 INotifier notificador) : base(notificador, FabricanteRepository)
        {
            _FabricanteRepository = FabricanteRepository;
        }

        public virtual async Task Adicionar(Fabricante Fabricante)
        {
            try
            {
                var fabricante = await _FabricanteRepository.Search(f => f.Nome == Fabricante.Nome);

                if (fabricante.Count() != 0)
                {
                    Notify("Já existe um fornecedor com este nome informado.");
                    return;
                }

                await _FabricanteRepository.Insert(Fabricante);

                Notify("Fornecedor incluído.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message +  ".");
            }
        }

        public virtual async Task Atualizar(Fabricante Fabricante)
        {
            try
            {
                if (!RunValidation(new FabricanteValidation(), Fabricante)) return;

                var exists = _FabricanteRepository.Exists(f => f.Nome == Fabricante.Nome && f.Id != Fabricante.Id);

                if (exists)
                {
                    Notify("Já existe um fornecedor com este nome informado.");
                    return;
                }

                await _FabricanteRepository.Update(Fabricante);

                Notify("Fabricante atualizado.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Remover(Guid id)
        {
            await _FabricanteRepository.Delete(id);
        }

        public Task<IPagedList<Fabricante>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _FabricanteRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _FabricanteRepository?.Dispose();
        }
    }
}
