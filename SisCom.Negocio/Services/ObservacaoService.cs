using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class ObservacaoService : BaseService<Observacao>, IObservacaoService
    {
        private readonly IObservacaoRepository _observacaoRepository;

        public ObservacaoService(IObservacaoRepository ObservacaoRepository,
                                 INotifier notificador) : base(notificador, ObservacaoRepository)
        {
            _observacaoRepository = ObservacaoRepository;
        }

        public Task<IPagedList<Observacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _observacaoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Descricao.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _observacaoRepository?.Dispose();
        }

        public async Task Adicionar(Observacao observacao)
        {
            try
            {
                //                var _observacao = await _observacaoRepository.Search(f => f.Nome == mercadoria.Nome);

                //if (_observacao.Count() != 0)
                //{
                //    Notify("Já existe uma observacação com esse nome informado.");
                //    return;
                //}

                observacao.UltimaAtualizacao = DateTime.Now;

                await _observacaoRepository.Insert(observacao);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }

        }

        public async Task Atualizar(Observacao observacao)
        {
            try
            {
                //if (!RunValidation(new PessoaValidation(), pessoa)) return;

                //var exists = _observacaoRepository.Exists(f => f.Nome == mercadoria.Nome && f.Id != mercadoria.Id);

                //if (exists)
                //{
                //    Notify("Já existe uma mercadoria com esse nome informado.");
                //    return;
                //}

                observacao.UltimaAtualizacao = DateTime.Now;

                await _observacaoRepository.Update(observacao);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Remover(Guid id)
        {
            await _observacaoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }
    }
}
