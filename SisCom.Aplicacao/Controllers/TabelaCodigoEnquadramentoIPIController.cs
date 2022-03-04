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
    public class TabelaCodigoEnquadramentoIPIController
    {
        static TabelaCodigoEnquadramentoIPIService _TabelaCodigoEnquadramentoIPIService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCodigoEnquadramentoIPIController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaCodigoEnquadramentoIPIService = new TabelaCodigoEnquadramentoIPIService(new TabelaCodigoEnquadramentoIPIRepository(this.MeuDbContext), notifier);
        }

        public async Task<TabelaCodigoEnquadramentoIPIViewModel> Adicionar(TabelaCodigoEnquadramentoIPIViewModel TabelaCodigoEnquadramentoIPIViewModel)
        {
            await _TabelaCodigoEnquadramentoIPIService.Adicionar(Declaracoes.mapper.Map<TabelaCodigoEnquadramentoIPI>(TabelaCodigoEnquadramentoIPIViewModel));

            return TabelaCodigoEnquadramentoIPIViewModel;
        }

        public async Task<TabelaCodigoEnquadramentoIPIViewModel> Atualizar(TabelaCodigoEnquadramentoIPIViewModel TabelaCodigoEnquadramentoIPIViewModel)
        {
            await _TabelaCodigoEnquadramentoIPIService.Atualizar(Declaracoes.mapper.Map<TabelaCodigoEnquadramentoIPI>(TabelaCodigoEnquadramentoIPIViewModel));

            return TabelaCodigoEnquadramentoIPIViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _TabelaCodigoEnquadramentoIPIService.Remover(id);

            return;
        }

        public async Task<TabelaCodigoEnquadramentoIPIViewModel> GetById(Guid id)
        {
            var obter = await _TabelaCodigoEnquadramentoIPIService.GetById(id);
            return Declaracoes.mapper.Map<TabelaCodigoEnquadramentoIPIViewModel>(obter);
        }

        public async Task<IEnumerable<TabelaCodigoEnquadramentoIPIViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaCodigoEnquadramentoIPIService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCodigoEnquadramentoIPIViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<DescricaoComboViewModel>> Combo(Expression<Func<TabelaCodigoEnquadramentoIPI, object>> order = null)
        {
            var combo = await _TabelaCodigoEnquadramentoIPIService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<DescricaoComboViewModel>>(combo);
        }
    }
}
