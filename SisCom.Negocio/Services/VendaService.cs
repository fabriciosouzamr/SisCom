using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class VendaService : BaseService<Venda>, IVendaService
    {
        private readonly IVendaRepository vendaRepository;

        public VendaService(IVendaRepository vendaRepository,
                            INotifier notificador) : base(notificador, vendaRepository)
        {
            this.vendaRepository = vendaRepository;
        }

        public Task<IPagedList<Venda>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return vendaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Observacao.Contains(parameters.Search)
            ), parameters);
        }

        public async Task Adicionar(Venda venda)
        {
            //if (!RunValidation(new Mer(), pessoa)) return;

            try
            {
                //var _venda = await vendaRepository.Search(f => f.Observacao == venda.Observacao);

                //if (_venda.Count() != 0)
                //{
                //    Notify("Já existe uma mercadoria com esse nome informado.");
                //    return;
                //}

                await vendaRepository.Insert(venda);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(Venda venda)
        {
            try
            {
                //if (!RunValidation(new PessoaValidation(), pessoa)) return;

                //var exists = vendaRepository.Exists(f => f.Observacao == venda.Observacao && f.Id != venda.Id);

                //if (exists)
                //{
                //    Notify("Já existe uma mercadoria com esse nome informado.");
                //    return;
                //}

                await vendaRepository.Update(venda);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await vendaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            vendaRepository?.Dispose();
        }
    }
}
