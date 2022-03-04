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
    public class TabelaOrigemMercadoriaServicoController
    {
        static TabelaOrigemMercadoriaServicoService _TabelaOrigemMercadoriaServicoService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaOrigemMercadoriaServicoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaOrigemMercadoriaServicoService = new TabelaOrigemMercadoriaServicoService(new TabelaOrigemMercadoriaServicoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaOrigemMercadoriaServicoViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaOrigemMercadoriaServicoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaOrigemMercadoriaServicoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<TabelaOrigemMercadoriaServicoViewModel>> Combo()
        {
            var combo = await _TabelaOrigemMercadoriaServicoService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<TabelaOrigemMercadoriaServicoViewModel>>(combo);
        }
    }
}
