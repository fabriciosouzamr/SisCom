using Funcoes._Enum;
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
    public class TabelaCST_IPIController
    {
        static TabelaCST_IPIService _tabelaCST_IPIService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCST_IPIController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _tabelaCST_IPIService = new TabelaCST_IPIService(new TabelaCST_IPIRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaCST_IPIViewModel>> ObterTodos()
        {
            var obterTodos = await _tabelaCST_IPIService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCST_IPIViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> ComboCodigo(EntradaSaida entradaSaida, Expression<Func<TabelaCST_IPI, object>> order = null)
        {
            var combo = await _tabelaCST_IPIService.Search(p => p.EntradaSaida == entradaSaida, order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> ComboDescricao(EntradaSaida entradaSaida, Expression<Func<TabelaCST_IPI, object>> order = null)
        {
            var combo = await _tabelaCST_IPIService.Search(p => p.EntradaSaida == entradaSaida, order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
    }
}
