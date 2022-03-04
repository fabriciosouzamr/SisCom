using Funcoes._Enum;
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
    public class TabelaCST_PIS_COFINSController
    {
        static TabelaCST_PIS_COFINSService _TabelaCST_PIS_COFINSService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCST_PIS_COFINSController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaCST_PIS_COFINSService = new TabelaCST_PIS_COFINSService(new TabelaCST_PIS_COFINSRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<TabelaCST_PIS_COFINSViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaCST_PIS_COFINSService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCST_PIS_COFINSViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> ComboCodigoUsaEntrada(Expression<Func<TabelaCST_PIS_COFINS, object>> order = null)
        {
            var combo = await _TabelaCST_PIS_COFINSService.Search(p => p.UsaNaEntrada == true, order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> ComboCodigoUsaSaida(Expression<Func<TabelaCST_PIS_COFINS, object>> order = null)
        {
            var combo = await _TabelaCST_PIS_COFINSService.Search(p => p.UsaNaSaida == true, order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
