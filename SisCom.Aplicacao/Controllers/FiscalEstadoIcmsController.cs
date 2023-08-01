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
    public class FiscalEstadoIcmsController : IDisposable
    {
        static FiscalEstadoIcmsService fiscalEstadoIcmsService;
        private readonly MeuDbContext MeuDbContext;

        public FiscalEstadoIcmsController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            fiscalEstadoIcmsService = new FiscalEstadoIcmsService(new FiscalEstadoIcmsRepository(meuDbContext),
                                                                  notifier);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            return (await fiscalEstadoIcmsService.Excluir(Id));
        }
        public async Task<FiscalEstadoIcmsViewModel> Adicionar(FiscalEstadoIcmsViewModel FiscalEstadoIcmsViewModel)
        {
            var FiscalEstadoIcms = Declaracoes.mapper.Map<FiscalEstadoIcms>(FiscalEstadoIcmsViewModel);

            await fiscalEstadoIcmsService.Adicionar(FiscalEstadoIcms);

            return Declaracoes.mapper.Map<FiscalEstadoIcmsViewModel>(FiscalEstadoIcms);
        }
        public async Task<FiscalEstadoIcmsViewModel> Atualizar(Guid id, FiscalEstadoIcmsViewModel FiscalEstadoIcmsViewModel)
        {
            await fiscalEstadoIcmsService.Atualizar(Declaracoes.mapper.Map<FiscalEstadoIcms>(FiscalEstadoIcmsViewModel));

            return FiscalEstadoIcmsViewModel;
        }
        public async Task<IEnumerable<FiscalEstadoIcmsViewModel>> ObterTodos(Expression<Func<FiscalEstadoIcms, object>> order = null,
                                                                       Expression<Func<FiscalEstadoIcms, bool>> predicate = null)
        {
            var obterTodos = await fiscalEstadoIcmsService.GetAll(order, predicate, null);
            return Declaracoes.mapper.Map<IEnumerable<FiscalEstadoIcmsViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<FiscalEstadoIcmsViewModel>> PesquisarId(Guid Id)
        {
            var FiscalEstadoIcms = await fiscalEstadoIcmsService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<FiscalEstadoIcmsViewModel>>(FiscalEstadoIcms);
        }
        public async Task<IEnumerable<CodigoNomeComboViewModel>> Combo(Expression<Func<FiscalEstadoIcms, object>> order = null)
        {
            var combo = await fiscalEstadoIcmsService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoNomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
