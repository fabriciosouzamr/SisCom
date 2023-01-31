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
    public class UnidadeMedidaService : BaseService<UnidadeMedida>, IUnidadeMedidaService
    {
        private readonly IUnidadeMedidaRepository unidadeMedidaRepository;

        public UnidadeMedidaService(IUnidadeMedidaRepository UnidadeMedidaRepository,
                                 INotifier notificador) : base(notificador, UnidadeMedidaRepository)
        {
            unidadeMedidaRepository = UnidadeMedidaRepository;
        }
        public Task<IPagedList<UnidadeMedida>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return unidadeMedidaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }
        public virtual async Task Adicionar(UnidadeMedida unidadeMedida)
        {
            try
            {
                var empresa = await unidadeMedidaRepository.Search(f => f.Nome == unidadeMedida.Nome);

                if (empresa.Count() != 0)
                {
                    Notify("Já existe uma unidade de medida com este nome informada.");
                    return;
                }

                await unidadeMedidaRepository.Insert(unidadeMedida);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public virtual async Task Atualizar(UnidadeMedida unidadeMedida)
        {
            try
            {
                var exists = unidadeMedidaRepository.Exists(f => (f.Nome == unidadeMedida.Nome) && (f.Id != unidadeMedida.Id));

                if (exists)
                {
                    Notify("Já existe uma unidade de medida com este nome informada.");
                    return;
                }

                await unidadeMedidaRepository.Update(unidadeMedida);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public async Task Excluir(Guid id)
        {
            await unidadeMedidaRepository.Delete(id);
        }
    }
}
