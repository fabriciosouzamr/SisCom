using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class EstoqueLancamentoController : IDisposable
    {
        static EstoqueLancamentoService estoqueLancamentoService;
        static EstoqueController estoqueController;
        static MercadoriaUnidadeMedidaConversaoController mercadoriaUnidadeMedidaConversaoController;
        private readonly MeuDbContext MeuDbContext;

        public EstoqueLancamentoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            estoqueLancamentoService = new EstoqueLancamentoService(new EstoqueLancamentoRepository(this.MeuDbContext), notifier);

            estoqueController = new EstoqueController(this.MeuDbContext, notifier);
        }
        public async Task<EstoqueLancamentoViewModel> Adicionar(Guid almoxarifadoId, 
                                                                Guid mercadoriaId, 
                                                                Guid UnidadeMedidaId,
                                                                TipoLancamentoEstoque tipoLancamentoEstoque,
                                                                EntradaSaida entradaSaida, 
                                                                DateTime data, 
                                                                Double quantidade, 
                                                                String comentario = "")
        {
            var quantidadeEmEstoque = entradaSaida == EntradaSaida.Entrada ? quantidade : quantidade * -1;

            //var mercadoriaUnidadeMedidaConversao = await mercadoriaUnidadeMedidaConversaoController.Obter(w =>
            //    w.MercadoriaId == mercadoriaId && w.UnidadeMedidaId == UnidadeMedidaId);

            //if (mercadoriaUnidadeMedidaConversao.Any())
            //{
            //    quantidadeEmEstoque =
            //        quantidadeEmEstoque * mercadoriaUnidadeMedidaConversao.FirstOrDefault().FatorConversao;
            //}

            var estoque = await estoqueController.Atualizar(new EstoqueViewModel() { AlmoxarifadoId = almoxarifadoId, MercadoriaId = mercadoriaId, QuantidadeEmEstoque = quantidadeEmEstoque});

            var estoqueLancamentoViewModel = new EstoqueLancamento() { EstoqueId = estoque.Id,
                                                                       TipoLancamentoEstoque = tipoLancamentoEstoque, 
                                                                       Data = data, 
                                                                       Quantidade = quantidade,
                                                                       QuantidadeEmEstoque = Math.Abs(quantidadeEmEstoque),
                                                                       EntradaSaida = entradaSaida, 
                                                                       Comentario = comentario };

            await estoqueLancamentoService.Adicionar(estoqueLancamentoViewModel);

            return Declaracoes.mapper.Map<EstoqueLancamentoViewModel>(estoqueLancamentoViewModel);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await estoqueLancamentoService.Excluir(Id);

            return true;
        }
        public async Task<EstoqueLancamentoViewModel> GetById(Guid id)
        {
            var obter = await estoqueLancamentoService.GetById(id, e => e.Estoque, c => c.Estoque.Almoxarifado, c => c.Estoque.Mercadoria);
            return Declaracoes.mapper.Map<EstoqueLancamentoViewModel>(obter);
        }
        public async Task<IEnumerable<EstoqueLancamentoViewModel>> Obter(Expression<Func<EstoqueLancamento, object>> order = null, Expression<Func<EstoqueLancamento, bool>> predicate = null)
        {
            var obterTodos = await estoqueLancamentoService.GetAll(order, predicate, i => i.Estoque,
                                                                                                                      i => i.Estoque.Almoxarifado,
                                                                                                                      i => i.Estoque.Mercadoria);
            return Declaracoes.mapper.Map<IEnumerable<EstoqueLancamentoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<EstoqueLancamentoViewModel>> ObterTodos()
        {
            var obterTodos = await estoqueLancamentoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EstoqueLancamentoViewModel>>(obterTodos);
        }
        public void Dispose()
        {
            estoqueLancamentoService.Dispose();
            MeuDbContext.Dispose();
        }
    }
}
