using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class VendaMercadoriaService : BaseService<VendaMercadoria>, IVendaMercadoriaService
    {
        private readonly IVendaMercadoriaRepository vendaMercadoriaRepository;

        public VendaMercadoriaService(IVendaMercadoriaRepository vendaMercadoriaRepository,
                                      INotifier notificador) : base(notificador, vendaMercadoriaRepository)
        {
            this.vendaMercadoriaRepository = vendaMercadoriaRepository;
        }

        public Task<IPagedList<VendaMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return vendaMercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Id.ToString().Contains(parameters.Search)
            ), parameters);
        }

        public async Task Adicionar(VendaMercadoria vendaMercadoria)
        {
            //if (!RunValidation(new Mer(), pessoa)) return;

            try
            {
                var _vendaMercadoria = await vendaMercadoriaRepository.Search(f => f.Id.ToString() == vendaMercadoria.Id.ToString());

                if (_vendaMercadoria.Count() != 0)
                {
                    Notify("Já existe uma mercadoria com esse nome informado.");
                    return;
                }

                await vendaMercadoriaRepository.Insert(vendaMercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(VendaMercadoria vendaMercadoria)
        {
            try
            {
                //if (!RunValidation(new PessoaValidation(), pessoa)) return;

                var exists = vendaMercadoriaRepository.Exists(f => f.Id.ToString() == vendaMercadoria.Id.ToString() && f.Id != vendaMercadoria.Id);

                if (exists)
                {
                    Notify("Já existe uma mercadoria com esse nome informado.");
                    return;
                }

                await vendaMercadoriaRepository.Update(vendaMercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await vendaMercadoriaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            vendaMercadoriaRepository?.Dispose();
        }
    }
}