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
    public class TabelaBeneficioSPEDController
    {
        static TabelaBeneficioSPEDService _TabelaBeneficioSPEDService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaBeneficioSPEDController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaBeneficioSPEDService = new TabelaBeneficioSPEDService(new TabelaBeneficioSPEDRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaBeneficioSPEDViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaBeneficioSPEDService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaBeneficioSPEDViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoComboViewModel>> Combo(Expression<Func<TabelaBeneficioSPED, object>> order = null)
        {
            var combo = await _TabelaBeneficioSPEDService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoComboViewModel>>(combo);
        }
    }
}
