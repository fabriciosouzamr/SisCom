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
    public class EstoqueUnidadeMedidaConversaoService : BaseService<EstoqueUnidadeMedidaConversao>, IEstoqueUnidadeMedidaConversaoService
    {
        private readonly IEstoqueUnidadeMedidaConversaoRepository estoqueUnidadeMedidaConversaoRepository;

        public EstoqueUnidadeMedidaConversaoService(IEstoqueUnidadeMedidaConversaoRepository estoqueUnidadeMedidaConversaoRepository, 
                                                    INotifier notificador) : base(notificador, estoqueUnidadeMedidaConversaoRepository)
        {
            this.estoqueUnidadeMedidaConversaoRepository = estoqueUnidadeMedidaConversaoRepository;
        }

        public virtual async Task Adicionar(EstoqueUnidadeMedidaConversao estoqueUnidadeMedidaConversao)
        {
            try
            {
                var exists = await estoqueUnidadeMedidaConversaoRepository.Search(f => f.MercadoriaId == estoqueUnidadeMedidaConversao.MercadoriaId && 
                                                                                                                     f.UnidadeMedidaId == estoqueUnidadeMedidaConversao.UnidadeMedidaId);

                if (exists.Any())
                {
                    Notify("Já existe fator de conversão informado para essa mercadoria nessa unidade de medida.");
                    return;
                }

                await estoqueUnidadeMedidaConversaoRepository.Insert(estoqueUnidadeMedidaConversao);
            }
            catch (Exception ex)
            {
                Notify("EstoqueUnidadeMedidaConversaoService - Adicionar", ex);
            }
        }

        public virtual async Task Atualizar(EstoqueUnidadeMedidaConversao estoqueUnidadeMedidaConversao)
        {
            try
            {
                var exists = await estoqueUnidadeMedidaConversaoRepository.Search(f => f.MercadoriaId == estoqueUnidadeMedidaConversao.MercadoriaId &&
                                                                                                                     f.UnidadeMedidaId == estoqueUnidadeMedidaConversao.UnidadeMedidaId &&
                                                                                                                     f.Id != estoqueUnidadeMedidaConversao.Id);

                if (exists.Any())
                {
                    Notify("Já existe fator de conversão informado para essa mercadoria nessa unidade de medida.");
                    return;
                }

                await estoqueUnidadeMedidaConversaoRepository.Update(estoqueUnidadeMedidaConversao);
            }
            catch (Exception ex)
            {
                Notify("EstoqueService - Atualizar", ex);
            }
        }

        public async Task Excluir(Guid id)
        {
            await estoqueUnidadeMedidaConversaoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            estoqueUnidadeMedidaConversaoRepository?.Dispose();
        }

        public virtual async Task<IEnumerable<EstoqueUnidadeMedidaConversao>> Search(Expression<Func<EstoqueUnidadeMedidaConversao, bool>> predicate, Expression<Func<EstoqueUnidadeMedidaConversao, object>> order = null)
        {
            var estoqueUnidadeMedidaConversao = await estoqueUnidadeMedidaConversaoRepository.Search(predicate, order);

            return estoqueUnidadeMedidaConversao;
        }

        public Task<List<Estoque>> Combo(Expression<Func<Estoque, object>> order = null)
        {
            throw new NotImplementedException();
        }
    }

}
