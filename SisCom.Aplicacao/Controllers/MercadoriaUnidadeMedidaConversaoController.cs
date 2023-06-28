using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class MercadoriaUnidadeMedidaConversaoController : IDisposable
    {
        static MercadoriaUnidadeMedidaConversaoService estoqueUnidadeMedidaConversaoService;
        private readonly MeuDbContext MeuDbContext;

        public MercadoriaUnidadeMedidaConversaoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            estoqueUnidadeMedidaConversaoService = new MercadoriaUnidadeMedidaConversaoService(new MercadoriaUnidadeMedidaConversaoRepository(this.MeuDbContext), notifier);
        }
        public async Task<MercadoriaUnidadeMedidaConversaoViewModel> Adicionar(MercadoriaUnidadeMedidaConversaoViewModel nercadoriaUnidadeMedidaConversaoViewModel)
        {
            var nercadoriaUnidadeMedidaConversao = Declaracoes.mapper.Map<MercadoriaUnidadeMedidaConversao>(nercadoriaUnidadeMedidaConversaoViewModel);

            await estoqueUnidadeMedidaConversaoService.Adicionar(nercadoriaUnidadeMedidaConversao);

            return Declaracoes.mapper.Map<MercadoriaUnidadeMedidaConversaoViewModel>(nercadoriaUnidadeMedidaConversao);
        }

        public async Task<MercadoriaUnidadeMedidaConversaoViewModel> Atualizar(MercadoriaUnidadeMedidaConversaoViewModel nercadoriaUnidadeMedidaConversaoViewModel)
        {
            await estoqueUnidadeMedidaConversaoService.Atualizar(Declaracoes.mapper.Map<MercadoriaUnidadeMedidaConversao>(nercadoriaUnidadeMedidaConversaoViewModel));

            return nercadoriaUnidadeMedidaConversaoViewModel;
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await estoqueUnidadeMedidaConversaoService.Excluir(Id);

            return true;
        }
        public async Task<IEnumerable<MercadoriaUnidadeMedidaConversaoViewModel>> ObterTodos()
        {
            var obterTodos = await estoqueUnidadeMedidaConversaoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaUnidadeMedidaConversaoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<MercadoriaUnidadeMedidaConversaoViewModel>> Obter(Expression<Func<MercadoriaUnidadeMedidaConversao, bool>> where)
        {
            var obterTodos = await estoqueUnidadeMedidaConversaoService.GetAll(order: null, predicate: where, includes: null);
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaUnidadeMedidaConversaoViewModel>>(obterTodos);
        }
        public void Dispose()
        {
            estoqueUnidadeMedidaConversaoService.Dispose();
            MeuDbContext.Dispose();
        }
    }
}
