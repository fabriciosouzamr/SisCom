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
    public class TabelaCESTController
    {
        static TabelaCESTService _TabelaCESTService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCESTController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaCESTService = new TabelaCESTService(new TabelaCESTRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaCESTViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaCESTService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCESTViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Guid tabelaNCMId, Expression<Func<TabelaCEST, object>> order = null)
        {
            var combo = await _TabelaCESTService.ComboSearch(p => p.TabelaNCMId == tabelaNCMId, order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
