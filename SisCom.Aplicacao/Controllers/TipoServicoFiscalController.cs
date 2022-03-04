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
    public class TipoServicoFiscalController
    {
        static TipoServicoFiscalService _TipoServicoFiscalService;
        private readonly MeuDbContext MeuDbContext;

        public TipoServicoFiscalController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TipoServicoFiscalService = new TipoServicoFiscalService(new TipoServicoFiscalRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TipoServicoFiscalViewModel>> ObterTodos()
        {
            var obterTodos = await _TipoServicoFiscalService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TipoServicoFiscalViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<TipoServicoFiscal, object>> order = null)
        {
            var combo = await _TipoServicoFiscalService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
    }
}
