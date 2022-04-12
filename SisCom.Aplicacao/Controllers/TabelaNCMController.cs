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
    public class TabelaNCMController
    {
        static TabelaNCMService _TabelaNCMService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaNCMController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaNCMService = new TabelaNCMService(new TabelaNCMRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaNCMViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaNCMService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaNCMViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<TabelaNCM, object>> order = null)
        {
            var combo = await _TabelaNCMService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
