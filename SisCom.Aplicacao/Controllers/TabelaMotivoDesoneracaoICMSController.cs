using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
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
    public class TabelaMotivoDesoneracaoICMSController
    {
        static TabelaMotivoDesoneracaoICMSService _TabelaMotivoDesoneracaoICMSService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaMotivoDesoneracaoICMSController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaMotivoDesoneracaoICMSService = new TabelaMotivoDesoneracaoICMSService(new TabelaMotivoDesoneracaoICMSRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaMotivoDesoneracaoICMSViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaMotivoDesoneracaoICMSService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaMotivoDesoneracaoICMSViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<DescricaoComboViewModel>> Combo(Expression<Func<TabelaMotivoDesoneracaoICMS, object>> order = null)
        {
            var combo = await _TabelaMotivoDesoneracaoICMSService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<DescricaoComboViewModel>>(combo);
        }
    }
}
