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
    public class NaturezaOperacaoController : IDisposable
    {
        static NaturezaOperacaoService _NaturezaOperacaoService;
        private readonly MeuDbContext MeuDbContext;

        public NaturezaOperacaoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _NaturezaOperacaoService = new NaturezaOperacaoService(new NaturezaOperacaoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<NaturezaOperacaoViewModel>> ObterTodos()
        {
            var obterTodos = await _NaturezaOperacaoService.GetAll(o => o.Id, i => i.TabelaCFOP);
            return Declaracoes.mapper.Map<IEnumerable<NaturezaOperacaoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NaturezaOperacao, object>> order = null)
        {
            var combo = await _NaturezaOperacaoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
