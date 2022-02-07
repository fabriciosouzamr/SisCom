using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class PaisController
    {
        static PaisService _PaisService;

        static PaisController()
        {
            _PaisService = new PaisService(new PaisRepository(Declaracoes.dbContext), Declaracoes.Notifier);
        }

        public async Task<IEnumerable<PaisViewModel>> ObterTodos()
        {
            var obterTodos = await _PaisService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<PaisViewModel>> Combo()
        {
            var combo = await _PaisService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(combo);
        }
    }
}
