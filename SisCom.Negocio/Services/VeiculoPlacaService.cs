using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class VeiculoPlacaService : BaseService<VeiculoPlaca>, IVeiculoPlacaService
    {
        private readonly IVeiculoPlacaRepository veiculoPlacaRepository;

        public VeiculoPlacaService(IVeiculoPlacaRepository VeiculoPlacaRepository,
                                   INotifier notificador) : base(notificador, VeiculoPlacaRepository)
        {
            veiculoPlacaRepository = VeiculoPlacaRepository;
        }

        public Task<IPagedList<VeiculoPlaca>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return veiculoPlacaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.NumeroPlaca.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            veiculoPlacaRepository?.Dispose();
        }

        public async Task Adicionar(VeiculoPlaca veiculoPlaca)
        {
            try
            {
                await veiculoPlacaRepository.Insert(veiculoPlaca);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(VeiculoPlaca veiculoPlaca)
        {
            try
            {
                await veiculoPlacaRepository.Update(veiculoPlaca);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await veiculoPlacaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }
    }
}
