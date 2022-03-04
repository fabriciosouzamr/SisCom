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
    public class VinculoFiscalController
    {
        static VinculoFiscalService _VinculoFiscalService;
        private readonly MeuDbContext MeuDbContext;

        public VinculoFiscalController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _VinculoFiscalService = new VinculoFiscalService(new VinculoFiscalRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<VinculoFiscalViewModel>> ObterTodos()
        {
            var obterTodos = await _VinculoFiscalService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<VinculoFiscalViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<VinculoFiscal, object>> order = null)
        {
            var combo = await _VinculoFiscalService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
    }
}
