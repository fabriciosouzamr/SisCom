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
    public class TabelaClasseEnquadramentoIPIController
    {
        static TabelaClasseEnquadramentoIPIService _TabelaClasseEnquadramentoIPIService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaClasseEnquadramentoIPIController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaClasseEnquadramentoIPIService = new TabelaClasseEnquadramentoIPIService(new TabelaClasseEnquadramentoIPIRepository(this.MeuDbContext), notifier);
        }

        public async Task<TabelaClasseEnquadramentoIPIViewModel> Adicionar(TabelaClasseEnquadramentoIPIViewModel TabelaClasseEnquadramentoIPIViewModel)
        {
            await _TabelaClasseEnquadramentoIPIService.Adicionar(Declaracoes.mapper.Map<TabelaClasseEnquadramentoIPI>(TabelaClasseEnquadramentoIPIViewModel));

            return TabelaClasseEnquadramentoIPIViewModel;
        }

        public async Task<TabelaClasseEnquadramentoIPIViewModel> Atualizar(TabelaClasseEnquadramentoIPIViewModel TabelaClasseEnquadramentoIPIViewModel)
        {
            await _TabelaClasseEnquadramentoIPIService.Atualizar(Declaracoes.mapper.Map<TabelaClasseEnquadramentoIPI>(TabelaClasseEnquadramentoIPIViewModel));

            return TabelaClasseEnquadramentoIPIViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _TabelaClasseEnquadramentoIPIService.Remover(id);

            return;
        }

        public async Task<TabelaClasseEnquadramentoIPIViewModel> GetById(Guid id)
        {
            var obter = await _TabelaClasseEnquadramentoIPIService.GetById(id);
            return Declaracoes.mapper.Map<TabelaClasseEnquadramentoIPIViewModel>(obter);
        }

        public async Task<IEnumerable<TabelaClasseEnquadramentoIPIViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaClasseEnquadramentoIPIService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaClasseEnquadramentoIPIViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<TabelaClasseEnquadramentoIPI, object>> order = null)
        {
            var combo = await _TabelaClasseEnquadramentoIPIService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
