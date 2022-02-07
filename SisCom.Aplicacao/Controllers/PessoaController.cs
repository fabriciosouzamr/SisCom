using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class PessoaController
    {
        static PessoaService _PessoaService;

        static PessoaController()
        {
            _PessoaService = new PessoaService(new PessoaRepository(Declaracoes.dbContext), null);
        }

        public PessoaViewModel Adicionar(PessoaViewModel PessoaViewModel)
        {
            _PessoaService.Adicionar(Declaracoes.mapper.Map<Pessoa>(PessoaViewModel));

            return PessoaViewModel;
        }

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return Declaracoes.mapper.Map<IEnumerable<PessoaViewModel>>(_PessoaService.GetAll());
        }

        public async Task<IEnumerable<PessoaComboViewModel>> Combo()
        {
            var combo = await _PessoaService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboViewModel>>(combo);
        }

        public async Task<IEnumerable<PessoaComboViewModel>> ComboFornecedor()
        {
            var combo = await _PessoaService.ComboFornecedor();
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboViewModel>>(combo);
        }
    }
}
