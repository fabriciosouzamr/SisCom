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
    public class TabelaCST_CSOSNController : IDisposable
    {
        static TabelaCST_CSOSNService _TabelaCST_CSOSNService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCST_CSOSNController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaCST_CSOSNService = new TabelaCST_CSOSNService(new TabelaCST_CSOSNRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaCST_CSOSNViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaCST_CSOSNService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCST_CSOSNViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<TabelaCST_CSOSN, object>> order = null)
        {
            var combo = await _TabelaCST_CSOSNService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
