using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class MercadoriaUnidadeMedidaConversaoService : BaseService<MercadoriaUnidadeMedidaConversao>, IMercadoriaUnidadeMedidaConversaoService
    {
        private readonly IMercadoriaUnidadeMedidaConversaoRepository mercadoriaUnidadeMedidaConversaoRepository;

        public MercadoriaUnidadeMedidaConversaoService(IMercadoriaUnidadeMedidaConversaoRepository mercadoriaUnidadeMedidaConversaoRepository, 
                                                       INotifier notificador) : base(notificador, mercadoriaUnidadeMedidaConversaoRepository)
        {
            this.mercadoriaUnidadeMedidaConversaoRepository = mercadoriaUnidadeMedidaConversaoRepository;
        }

        public virtual async Task Adicionar(MercadoriaUnidadeMedidaConversao mercadoriaUnidadeMedidaConversao)
        {
            try
            {
                var exists = await mercadoriaUnidadeMedidaConversaoRepository.Search(f => f.MercadoriaId == mercadoriaUnidadeMedidaConversao.MercadoriaId && 
                                                                                                                          f.UnidadeMedidaId == mercadoriaUnidadeMedidaConversao.UnidadeMedidaId);

                if (exists.Any())
                {
                    Notify("Já existe fator de conversão informado para essa mercadoria nessa unidade de medida.");
                    return;
                }

                await mercadoriaUnidadeMedidaConversaoRepository.Insert(mercadoriaUnidadeMedidaConversao);
            }
            catch (Exception ex)
            {
                Notify("EstoqueUnidadeMedidaConversaoService - Adicionar", ex);
            }
        }

        public virtual async Task Atualizar(MercadoriaUnidadeMedidaConversao mercadoriaUnidadeMedidaConversao)
        {
            try
            {
                var exists = await mercadoriaUnidadeMedidaConversaoRepository.Search(f => f.MercadoriaId == mercadoriaUnidadeMedidaConversao.MercadoriaId &&
                                                                                                                          f.UnidadeMedidaId == mercadoriaUnidadeMedidaConversao.UnidadeMedidaId &&
                                                                                                                          f.Id != mercadoriaUnidadeMedidaConversao.Id);

                if (exists.Any())
                {
                    Notify("Já existe fator de conversão informado para essa mercadoria nessa unidade de medida.");
                    return;
                }

                await mercadoriaUnidadeMedidaConversaoRepository.Update(mercadoriaUnidadeMedidaConversao);
            }
            catch (Exception ex)
            {
                Notify("EstoqueService - Atualizar", ex);
            }
        }

        public async Task Excluir(Guid id)
        {
            await mercadoriaUnidadeMedidaConversaoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            mercadoriaUnidadeMedidaConversaoRepository?.Dispose();
        }

        public virtual async Task<IEnumerable<MercadoriaUnidadeMedidaConversao>> Search(Expression<Func<MercadoriaUnidadeMedidaConversao, bool>> predicate, Expression<Func<MercadoriaUnidadeMedidaConversao, object>> order = null)
        {
            var estoqueUnidadeMedidaConversao = await mercadoriaUnidadeMedidaConversaoRepository.Search(predicate, order);

            return estoqueUnidadeMedidaConversao;
        }

        public Task<List<Estoque>> Combo(Expression<Func<Estoque, object>> order = null)
        {
            throw new NotImplementedException();
        }
    }

}
