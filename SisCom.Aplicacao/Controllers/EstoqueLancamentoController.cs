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
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class EstoqueLancamentoController : IDisposable
    {
        static EstoqueLancamentoService estoqueLancamentoService;
        static EstoqueController estoqueController;
        private readonly MeuDbContext MeuDbContext;

        public EstoqueLancamentoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            estoqueLancamentoService = new EstoqueLancamentoService(new EstoqueLancamentoRepository(this.MeuDbContext), notifier);

            estoqueController = new EstoqueController(this.MeuDbContext, notifier);
        }
        public async Task<EstoqueLancamentoViewModel> Adicionar(Guid almoxarifadoId, 
                                                                Guid mercadoriaId, 
                                                                TipoLancamentoEstoque tipoLancamentoEstoque,
                                                                EntradaSaida entradaSaida, 
                                                                DateTime data, 
                                                                Double quantidade, 
                                                                String comentario = "")
        {
            var quantidadeEmEstoque = entradaSaida == EntradaSaida.Entrada ? quantidade : quantidade * -1;

            var estoque = await estoqueController.Atualizar(new EstoqueViewModel() { AlmoxarifadoId = almoxarifadoId, MercadoriaId = mercadoriaId, QuantidadeEmEstoque = quantidadeEmEstoque});

            var estoqueLancamentoViewModel = new EstoqueLancamento() { EstoqueId = estoque.Id,
                                                                       TipoLancamentoEstoque = tipoLancamentoEstoque, 
                                                                       Data = data, 
                                                                       Quantidade = quantidade, 
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
