using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class UnidadeMedidaController
    {
        static UnidadeMedidaService _UnidadeMedidaService;

        static UnidadeMedidaController()
        {
            _UnidadeMedidaService = new UnidadeMedidaService(new UnidadeMedidaRepository(Declaracoes.dbContext), Declaracoes.Notifier);
        }

        public async Task<IEnumerable<UnidadeMedidaViewModel>> ObterTodos()
        {
            var obterTodos = await _UnidadeMedidaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<UnidadeMedidaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<UnidadeMedidaViewModel>> Combo()
        {
            var combo = await _UnidadeMedidaService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<UnidadeMedidaViewModel>>(combo);
        }
    }
}
