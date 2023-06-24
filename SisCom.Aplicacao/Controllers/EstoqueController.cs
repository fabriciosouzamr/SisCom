using Funcoes._Entity;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
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
    public class EstoqueController : IDisposable
    {
        static EstoqueService estoqueService;
        private readonly MeuDbContext MeuDbContext;

        public EstoqueController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            estoqueService = new EstoqueService(new EstoqueRepository(this.MeuDbContext), notifier);
        }
        public async Task<EstoqueViewModel> Atualizar(EstoqueViewModel estoque)
        {
            var pesqestoque = (await estoqueService.Search(e => e.AlmoxarifadoId == estoque.AlmoxarifadoId && e.MercadoriaId == estoque.MercadoriaId)).FirstOrDefault();

            if (pesqestoque != null)
            {
                pesqestoque.QuantidadeEmEstoque += estoque.QuantidadeEmEstoque;
                pesqestoque.QuantidadeBloqueada += estoque.QuantidadeBloqueada;
                await estoqueService.Atualizar(pesqestoque); 
            }
            else
            {
                pesqestoque = new Estoque()
                {
                    AlmoxarifadoId = estoque.AlmoxarifadoId,
                    MercadoriaId = estoque.MercadoriaId,
                    QuantidadeEmEstoque = estoque.QuantidadeEmEstoque,
                    QuantidadeBloqueada = estoque.QuantidadeBloqueada
                };
                await estoqueService.Adicionar(pesqestoque); 
            }

            return Declaracoes.mapper.Map<EstoqueViewModel>(pesqestoque);
        }
        public async Task<EstoqueViewModel> GetById(Guid id)
        {
            var obter = await estoqueService.GetById(id, e => e.Almoxarifado, e => e.Mercadoria);
            return Declaracoes.mapper.Map<EstoqueViewModel>(obter);
        }
        public async Task<IEnumerable<EstoqueViewModel>> Obter(Expression<Func<Estoque, object>> order = null, Expression<Func<Estoque, bool>> predicate = null, params Expression<Func<Estoque, object>>[] includes)
        {
            var obterTodos = await estoqueService.GetAll(order, predicate, includes);
            return Declaracoes.mapper.Map<IEnumerable<EstoqueViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<EstoqueViewModel>> ObterTodos()
        {
            var obterTodos = await estoqueService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EstoqueViewModel>>(obterTodos);
        }
        public void Dispose()
        {
            estoqueService.Dispose();
            MeuDbContext.Dispose();
        }
    }

}
