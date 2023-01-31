using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class CondutorController : IDisposable
    {
        static CondutorService condutorService;
        private readonly MeuDbContext meuDbContext;

        public CondutorController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.meuDbContext = MeuDbContext;

            condutorService = new CondutorService(new CondutorRepository(this.meuDbContext), notifier);
        }
        public async Task<IEnumerable<CondutorViewModel>> Combo(Expression<Func<Condutor, object>> order = null)
        {
            var combo = await condutorService.GetAll(order);
            return Declaracoes.mapper.Map<IEnumerable<CondutorViewModel>>(combo);
        }
        public async Task<IEnumerable<CondutorViewModel>> ObterTodos(Expression<Func<Condutor, object>> order = null)
        {
            var obterTodos = await condutorService.GetAll(order);
            return Declaracoes.mapper.Map<IEnumerable<CondutorViewModel>>(obterTodos);
        }
        public async Task<CondutorViewModel> Adicionar(CondutorViewModel condutorViewModel)
        {
            await condutorService.Adicionar(Declaracoes.mapper.Map<Condutor>(condutorViewModel));

            return condutorViewModel;
        }
        public async Task<CondutorViewModel> Atualizar(CondutorViewModel condutorViewModel)
        {
            await condutorService.Atualizar(Declaracoes.mapper.Map<Condutor>(condutorViewModel));

            return condutorViewModel;
        }
        public async Task Remover(Guid id)
        {
            await condutorService.Excluir(id);

            return;
        }
        public void Dispose()
        {
        }
    }
}
