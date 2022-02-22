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
    public class EmpresaController
    {
        static EmpresaService _EmpresaService;
        private readonly MeuDbContext MeuDbContext;

        public EmpresaController(MeuDbContext MeuDbContext)
        {
            this.MeuDbContext = MeuDbContext;

            _EmpresaService = new EmpresaService(new EmpresaRepository(this.MeuDbContext), null);
        }

        public async Task<EmpresaViewModel> Adicionar(EmpresaViewModel EmpresaViewModel)
        {
            await _EmpresaService.Adicionar(Declaracoes.mapper.Map<Empresa>(EmpresaViewModel));

            return EmpresaViewModel;
        }

        public async Task<EmpresaViewModel> Atualizar(EmpresaViewModel EmpresaViewModel)
        {
            await _EmpresaService.Atualizar(Declaracoes.mapper.Map<Empresa>(EmpresaViewModel));

            return EmpresaViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _EmpresaService.Remover(id);

            return;
        }

        public async Task<EmpresaViewModel> GetById(Guid id)
        {
            var obter = await _EmpresaService.GetById(id);
            return Declaracoes.mapper.Map<EmpresaViewModel>(obter);
        }

        public async Task<EmpresaViewModel> GetByName(string nome)
        {
            var grupo = await _EmpresaService.Search(f => f.Unidade == nome);
            return Declaracoes.mapper.Map<EmpresaViewModel>(grupo);
        }

        public async Task<IEnumerable<EmpresaViewModel>> ObterTodos()
        {
            var obterTodos = await _EmpresaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EmpresaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<EmpresaComboViewModel>> Combo(Expression<Func<Empresa, object>> order = null)
        {
            var combo = await _EmpresaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<EmpresaComboViewModel>>(combo);
        }
    }
}
