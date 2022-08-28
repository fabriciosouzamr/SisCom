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
    public class FormaPagamentoController : IDisposable
    {
        static FormaPagamentoService _FormaPagamentoService;
        private readonly MeuDbContext MeuDbContext;

        public FormaPagamentoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _FormaPagamentoService = new FormaPagamentoService(new FormaPagamentoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<FormaPagamentoViewModel>> ObterTodos()
        {
            var obterTodos = await _FormaPagamentoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<FormaPagamentoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<FormaPagamento, object>> order = null)
        {
            var combo = await _FormaPagamentoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
