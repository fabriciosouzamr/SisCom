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
    public class TabelaModalidadeDeterminacaoBCICMSController
    {
        static TabelaModalidadeDeterminacaoBCICMSService _TabelaModalidadeDeterminacaoBCICMSService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaModalidadeDeterminacaoBCICMSController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaModalidadeDeterminacaoBCICMSService = new TabelaModalidadeDeterminacaoBCICMSService(new TabelaModalidadeDeterminacaoBCICMSRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaModalidadeDeterminacaoBCICMSViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaModalidadeDeterminacaoBCICMSService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaModalidadeDeterminacaoBCICMSViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<DescricaoComboViewModel>> Combo(TipoModalidadeDeterminacaoBCICMS tipoModalidadeDeterminacaoBCICMS, Expression<Func<TabelaModalidadeDeterminacaoBCICMS, object>> order = null)
        {
            var combo = await _TabelaModalidadeDeterminacaoBCICMSService.Search(p => p.TipoModalidadeDeterminacaoBCICMS == tipoModalidadeDeterminacaoBCICMS, order);
            return Declaracoes.mapper.Map<IEnumerable<DescricaoComboViewModel>>(combo);
        }
    }
}
