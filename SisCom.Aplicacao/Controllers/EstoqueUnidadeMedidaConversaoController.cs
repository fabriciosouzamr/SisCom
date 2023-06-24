using DanfeSharp.Modelo;
using Funcoes._Entity;
using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class EstoqueUnidadeMedidaConversaoController : IDisposable
    {
        static EstoqueUnidadeMedidaConversaoService estoqueUnidadeMedidaConversaoService;
        static EstoqueController estoqueController;
        private readonly MeuDbContext MeuDbContext;

        public EstoqueUnidadeMedidaConversaoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            estoqueUnidadeMedidaConversaoService = new EstoqueUnidadeMedidaConversaoService(new EstoqueUnidadeMedidaConversaoRepository(this.MeuDbContext), notifier);

            estoqueController = new EstoqueController(this.MeuDbContext, notifier);
        }
        public async Task<EstoqueUnidadeMedidaConversaoViewModel> Adicionar(EstoqueUnidadeMedidaConversaoViewModel estoqueUnidadeMedidaConversao)
        {
            var empresa = Declaracoes.mapper.Map<EstoqueUnidadeMedidaConversao>(estoqueUnidadeMedidaConversao);

            await estoqueUnidadeMedidaConversaoService.Adicionar(empresa);

            return Declaracoes.mapper.Map<EstoqueUnidadeMedidaConversaoViewModel>(empresa);
        }

        public async Task<EstoqueUnidadeMedidaConversaoViewModel> Atualizar(EstoqueUnidadeMedidaConversaoViewModel estoqueUnidadeMedidaConversao)
        {
            await estoqueUnidadeMedidaConversaoService.Atualizar(Declaracoes.mapper.Map<EstoqueUnidadeMedidaConversao>(estoqueUnidadeMedidaConversao));

            return estoqueUnidadeMedidaConversao;
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await estoqueUnidadeMedidaConversaoService.Excluir(Id);

            return true;
        }
        public async Task<IEnumerable<EstoqueUnidadeMedidaConversaoViewModel>> ObterTodos()
        {
            var obterTodos = await estoqueUnidadeMedidaConversaoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EstoqueUnidadeMedidaConversaoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<EstoqueUnidadeMedidaConversaoViewModel>> Obter(Expression<Func<EstoqueUnidadeMedidaConversao, bool>> where)
        {
            var obterTodos = await estoqueUnidadeMedidaConversaoService.GetAll(order: null, predicate: where, includes: null);
            return Declaracoes.mapper.Map<IEnumerable<EstoqueUnidadeMedidaConversaoViewModel>>(obterTodos);
        }
        public void Dispose()
        {
            estoqueUnidadeMedidaConversaoService.Dispose();
            MeuDbContext.Dispose();
        }
    }
}
