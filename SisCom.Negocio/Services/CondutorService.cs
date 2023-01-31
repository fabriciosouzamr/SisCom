using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class CondutorService : BaseService<Condutor>, ICondutorService
    {
        private readonly ICondutorRepository condutorRepository;

        public CondutorService(ICondutorRepository condutorRepository,
                               INotifier notificador) : base(notificador, condutorRepository)
        {
            this.condutorRepository = condutorRepository;
        }
        public Task<IPagedList<Condutor>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return condutorRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }
        public override void Dispose()
        {
            condutorRepository?.Dispose();
        }
        public virtual async Task Adicionar(Condutor condutor)
        {
            try
            {
                await condutorRepository.Insert(condutor);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public virtual async Task Atualizar(Condutor condutor)
        {
            try
            {
                await condutorRepository.Update(condutor);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public async Task Excluir(Guid id)
        {
            await condutorRepository.Delete(id);
        }
    }
}
