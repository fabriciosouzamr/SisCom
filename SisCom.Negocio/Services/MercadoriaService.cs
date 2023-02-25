using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class MercadoriaService : BaseService<Mercadoria>, IMercadoriaService
    {
        private readonly IMercadoriaRepository mercadoriaRepository;
        private readonly INotaFiscalEntradaMercadoriaRepository notaFiscalEntradaMercadoriaRepository;
        private readonly INotaFiscalSaidaMercadoriaRepository notaFiscalSaidaMercadoriaRepository;
        private readonly IVendaMercadoriaRepository vendaMercadoriaRepository;

        public MercadoriaService(IMercadoriaRepository MercadoriaRepository,
                                 INotaFiscalEntradaMercadoriaRepository notaFiscalEntradaMercadoriaRepository,
                                 INotaFiscalSaidaMercadoriaRepository notaFiscalSaidaMercadoriaRepository,
                                 IVendaMercadoriaRepository vendaMercadoriaRepository,
                                 INotifier notificador) : base(notificador, MercadoriaRepository)
        {
            this.mercadoriaRepository = MercadoriaRepository;
            this.notaFiscalEntradaMercadoriaRepository = notaFiscalEntradaMercadoriaRepository;
            this.notaFiscalSaidaMercadoriaRepository = notaFiscalSaidaMercadoriaRepository;
            this.vendaMercadoriaRepository = vendaMercadoriaRepository;
        }

        public Task<IPagedList<Mercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return mercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public async Task Adicionar(Mercadoria mercadoria)
        {
            //if (!RunValidation(new Mer(), pessoa)) return;

            try
            {
                /*var _pessoa = await mercadoriaRepository.Search(f => f.Nome == mercadoria.Nome);

                if (_pessoa.Count() != 0)
                {
                    Notify("Já existe uma mercadoria com esse nome informado.");
                    return;
                }*/

                await mercadoriaRepository.Insert(mercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(Mercadoria mercadoria)
        {
            try
            {
                //if (!RunValidation(new PessoaValidation(), pessoa)) return;

                /*var exists = mercadoriaRepository.Exists(f => f.Nome == mercadoria.Nome && f.Id != mercadoria.Id);

                if (exists)
                {
                    Notify("Já existe uma mercadoria com esse nome informado.");
                    return;
                }*/

                await mercadoriaRepository.Update(mercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            if ((await notaFiscalEntradaMercadoriaRepository.Search(predicate: p => p.MercadoriaId == id)).Any())
            {
                Notify("Existe Notas Fiscais de Entrada para essa mercadoria.");
                return false;
            }
            if ((await notaFiscalSaidaMercadoriaRepository.Search(predicate: p => p.MercadoriaId == id)).Any())
            {
                Notify("Existe Notas Fiscais de Saída para essa mercadoria.");
                return false;
            }
            if ((await vendaMercadoriaRepository.Search(predicate: p => p.MercadoriaId == id)).Any())
            {
                Notify("Existe Venda para essa mercadoria.");
                return false;
            }

            await mercadoriaRepository.Delete(id);

            Notify("Exclusão Efetuada.");

            return true;
        }

        public override void Dispose()
        {
            mercadoriaRepository?.Dispose();
        }
    }
}
