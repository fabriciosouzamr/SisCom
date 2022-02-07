using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class EstadoController
    {
        static EstadoService _EstadoService;

        static EstadoController()
        {
            _EstadoService = new EstadoService(new EstadoRepository(Declaracoes.dbContext), Declaracoes.Notifier);
        }

        public async Task<IEnumerable<EstadoViewModel>> ObterTodos()
        {
            var obterTodos = await _EstadoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EstadoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<EstadoViewModel>> Combo()
        {
            var combo = await _EstadoService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<EstadoViewModel>>(combo);
        }
    }
}
