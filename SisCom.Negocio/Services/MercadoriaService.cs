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

        public MercadoriaService(IMercadoriaRepository MercadoriaRepository,
                                 INotifier notificador) : base(notificador, MercadoriaRepository)
        {
            mercadoriaRepository = MercadoriaRepository;
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

        public async Task Excluir(Guid id)
        {
            await mercadoriaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            mercadoriaRepository?.Dispose();
        }
    }
}
