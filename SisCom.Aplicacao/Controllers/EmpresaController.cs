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
    public class EmpresaController : IDisposable
    {
        static EmpresaService _empresaService;
        private readonly MeuDbContext MeuDbContext;

        public EmpresaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _empresaService = new EmpresaService(new EmpresaRepository(this.MeuDbContext), notifier);
        }

        public async Task<EmpresaViewModel> Adicionar(EmpresaViewModel empresaViewModel)
        {
            var empresa = Declaracoes.mapper.Map<Empresa>(empresaViewModel);

            await _empresaService.Adicionar(empresa);

            return Declaracoes.mapper.Map<EmpresaViewModel>(empresa);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _empresaService.Excluir(Id);

            return true;
        }

        public async Task<EmpresaViewModel> Atualizar(Guid id, EmpresaViewModel empresaViewModel)
        {
            await _empresaService.Atualizar(Declaracoes.mapper.Map<Empresa>(empresaViewModel));

            return empresaViewModel;
        }

        public async Task<EmpresaViewModel> AtualizarNSU(Guid id, string sNSU)
        {
            var empresa = await GetById(id);

            empresa.NSU = sNSU;

            await _empresaService.Atualizar(Declaracoes.mapper.Map<Empresa>(empresa));

            return empresa;
        }

        public async Task<EmpresaViewModel> GetById(Guid id)
        {
            var obter = await _empresaService.GetById(id, e => e.Endereco.End_Cidade, c => c.Endereco.End_Cidade.Estado);
            return Declaracoes.mapper.Map<EmpresaViewModel>(obter);
        }

        public async Task<EmpresaViewModel> GetByName(string nome)
        {
            var grupo = await _empresaService.Search(f => f.Unidade == nome);
            return Declaracoes.mapper.Map<EmpresaViewModel>(grupo);
        }

        public async Task<IEnumerable<EmpresaViewModel>> ObterTodos()
        {
            var obterTodos = await _empresaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EmpresaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<EmpresaComboViewModel>> Combo(Expression<Func<Empresa, object>> order = null)
        {
            var combo = await _empresaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<EmpresaComboViewModel>>(combo);
        }

        public async Task<IEnumerable<EmpresaNuvemFiscalComboViewModel>> ComboNuvemFiscal(Expression<Func<Empresa, object>> order = null)
        {
            var combo = await _empresaService.GetAll(order, f => f.NuvemFiscal_Usar == true, i => i.Endereco.End_Cidade.Estado);
            return Declaracoes.mapper.Map<IEnumerable<EmpresaNuvemFiscalComboViewModel>>(combo);
        }
        public void Dispose()
        {
            _empresaService.Dispose();
        }
    }
}
