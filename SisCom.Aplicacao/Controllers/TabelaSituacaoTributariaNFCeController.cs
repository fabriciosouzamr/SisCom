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
    public class TabelaSituacaoTributariaNFCeController
    {
        static TabelaSituacaoTributariaNFCeService _TabelaSituacaoTributariaNFCeService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaSituacaoTributariaNFCeController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaSituacaoTributariaNFCeService = new TabelaSituacaoTributariaNFCeService(new TabelaSituacaoTributariaNFCeRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaSituacaoTributariaNFCeViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaSituacaoTributariaNFCeService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaSituacaoTributariaNFCeViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<DescricaoComboViewModel>> Combo(Expression<Func<TabelaSituacaoTributariaNFCe, object>> order = null)
        {
            var combo = await _TabelaSituacaoTributariaNFCeService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<DescricaoComboViewModel>>(combo);
        }
    }
}
