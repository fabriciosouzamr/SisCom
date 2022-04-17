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
    public class GrupoNaturezaReceita_CTS_PIS_COFINSController
    {
        static GrupoNaturezaReceita_CTS_PIS_COFINSService _GrupoNaturezaReceita_CTS_PIS_COFINSService;
        private readonly MeuDbContext MeuDbContext;

        public GrupoNaturezaReceita_CTS_PIS_COFINSController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _GrupoNaturezaReceita_CTS_PIS_COFINSService = new GrupoNaturezaReceita_CTS_PIS_COFINSService(new GrupoNaturezaReceita_CTS_PIS_COFINSRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<GrupoNaturezaReceita_CTS_PIS_COFINSViewModel>> ObterTodos()
        {
            var obterTodos = await _GrupoNaturezaReceita_CTS_PIS_COFINSService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<GrupoNaturezaReceita_CTS_PIS_COFINSViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<GrupoNaturezaReceita_CTS_PIS_COFINS, object>> order = null)
        {
            var combo = await _GrupoNaturezaReceita_CTS_PIS_COFINSService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
