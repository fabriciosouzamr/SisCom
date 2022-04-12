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
        private readonly IMercadoriaRepository mMercadoriaRepository;

        public MercadoriaService(IMercadoriaRepository MercadoriaRepository,
                                 INotifier notificador) : base(notificador, MercadoriaRepository)
        {
            mMercadoriaRepository = MercadoriaRepository;
        }

        public Task<IPagedList<Mercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return mMercadoriaRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public async Task Adicionar(Mercadoria mercadoria)
        {
            //if (!RunValidation(new Mer(), pessoa)) return;

            try
            {
                var _pessoa = await mMercadoriaRepository.Search(f => f.Nome == mercadoria.Nome);

                if (_pessoa.Count() != 0)
                {
                    Notify("Já existe uma mercadoria com esse nome informado.");
                    return;
                }

                await mMercadoriaRepository.Insert(mercadoria);
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

                var exists = mMercadoriaRepository.Exists(f => f.Nome == mercadoria.Nome && f.Id != mercadoria.Id);

                if (exists)
                {
                    Notify("Já existe uma mercadoria com esse nome informado.");
                    return;
                }

                await mMercadoriaRepository.Update(mercadoria);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await mMercadoriaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            mMercadoriaRepository?.Dispose();
        }
    }
}
