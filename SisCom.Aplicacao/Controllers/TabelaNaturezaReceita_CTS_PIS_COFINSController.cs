using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class TabelaNaturezaReceita_CTS_PIS_COFINSController
    {
        static TabelaNaturezaReceita_CTS_PIS_COFINSService _TabelaNaturezaReceita_CTS_PIS_COFINSService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaNaturezaReceita_CTS_PIS_COFINSController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaNaturezaReceita_CTS_PIS_COFINSService = new TabelaNaturezaReceita_CTS_PIS_COFINSService(new TabelaNaturezaReceita_CTS_PIS_COFINSRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaNaturezaReceita_CTS_PIS_COFINSViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaNaturezaReceita_CTS_PIS_COFINSService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaNaturezaReceita_CTS_PIS_COFINSViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<TabelaNaturezaReceita_CTS_PIS_COFINSViewModel>> Combo()
        {
            var combo = await _TabelaNaturezaReceita_CTS_PIS_COFINSService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<TabelaNaturezaReceita_CTS_PIS_COFINSViewModel>>(combo);
        }
    }
}
