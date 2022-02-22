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
    public class PessoaController
    {
        static PessoaService _PessoaService;
        private readonly MeuDbContext MeuDbContext;

        public PessoaController(MeuDbContext MeuDbContext)
        {
            this.MeuDbContext = MeuDbContext;

            _PessoaService = new PessoaService(new PessoaRepository(MeuDbContext), null);
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

        public async Task<IEnumerable<PessoaComboViewModel>> ComboFornecedor(Expression<Func<Pessoa, object>> order = null)
        {
            var combo = await _PessoaService.ComboFornecedor(order);
            return Declaracoes.mapper.Map<IEnumerable<PessoaComboViewModel>>(combo);
        }
    }
}
