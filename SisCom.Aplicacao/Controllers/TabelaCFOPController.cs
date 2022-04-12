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
    public class TabelaCFOPController
    {
        static TabelaCFOPService _TabelaCFOPService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCFOPController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaCFOPService = new TabelaCFOPService(new TabelaCFOPRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaCFOPViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaCFOPService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCFOPViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoComboViewModel>> Combo(Expression<Func<TabelaCFOP, object>> order = null)
        {
            var combo = await _TabelaCFOPService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoComboViewModel>>(combo);
        }
    }
}
