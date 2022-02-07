using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class CidadeController
    {
        static CidadeService _CidadeService;

        static CidadeController()
        {
            _CidadeService = new CidadeService(new CidadeRepository(Declaracoes.dbContext), Declaracoes.Notifier);
        }

        public async Task<IEnumerable<CidadeViewModel>> ObterTodos()
        {
            var obterTodos = await _CidadeService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<CidadeViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CidadeViewModel>> Combo()
        {
            var combo = await _CidadeService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<CidadeViewModel>>(combo);
        }
    }
}
