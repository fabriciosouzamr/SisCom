using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
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

            estoqueService = new EstoqueService(new EstoqueRepository(this.MeuDbContext),
                                                 notifier);
        }

        public async Task<EstoqueViewModel> Adicionar(EstoqueViewModel EstoqueViewModel)
        {
            var Estoque = Declaracoes.mapper.Map<Estoque>(EstoqueViewModel);

            await estoqueService.Adicionar(Estoque);

            return Declaracoes.mapper.Map<EstoqueViewModel>(Estoque);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await estoqueService.Excluir(Id);

            return true;
        }

        public async Task<EstoqueViewModel> Atualizar(Guid id, EstoqueViewModel EstoqueViewModel)
        {
            await estoqueService.Atualizar(Declaracoes.mapper.Map<Estoque>(EstoqueViewModel));

            return EstoqueViewModel;
        }

        public async Task<EstoqueViewModel> AtualizarNSU(Guid id, string sNSU)
        {
            var Estoque = await GetById(id);

            await estoqueService.Atualizar(Declaracoes.mapper.Map<Estoque>(Estoque));

            return Estoque;
        }

        public async Task<EstoqueViewModel> GetById(Guid id)
        {
            var obter = await estoqueService.GetById(id, e => e.Almoxarifado, e => e.Mercadoria);
            return Declaracoes.mapper.Map<EstoqueViewModel>(obter);
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
