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
    public class TabelaCFOPController : IDisposable
    {
        static TabelaCFOPService _TabelaCFOPService;
        private readonly MeuDbContext MeuDbContext;

        public TabelaCFOPController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TabelaCFOPService = new TabelaCFOPService(new TabelaCFOPRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TabelaCFOPViewModel>> ObterTodos()
        {
            var obterTodos = await _TabelaCFOPService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TabelaCFOPViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoComboViewModel>> Combo(EntradaSaida entradaSaida, Expression<Func<TabelaCFOP, object>> order = null)
        {
            if (entradaSaida == EntradaSaida.Entrada)
            { 
                var combo = await _TabelaCFOPService.GetAll(order, w => ( w.GrupoCFOP.TipoOperacaoCFOP == Entidade.Enum.TipoOperacaoCFOP.EntradaDentroEstado ||
                                                                          w.GrupoCFOP.TipoOperacaoCFOP == Entidade.Enum.TipoOperacaoCFOP.EntradaForaEstado ||
                                                                          w.GrupoCFOP.TipoOperacaoCFOP == Entidade.Enum.TipoOperacaoCFOP.EntradaExterior), i => i.GrupoCFOP);
                return Declaracoes.mapper.Map<IEnumerable<CodigoComboViewModel>>(combo);
            }
            else
            { 
                var combo = await _TabelaCFOPService.GetAll(order, w => (w.GrupoCFOP.TipoOperacaoCFOP == Entidade.Enum.TipoOperacaoCFOP.SaidaDentroEstado ||
                                                                         w.GrupoCFOP.TipoOperacaoCFOP == Entidade.Enum.TipoOperacaoCFOP.SaidaForaEstado ||
                                                                         w.GrupoCFOP.TipoOperacaoCFOP == Entidade.Enum.TipoOperacaoCFOP.SaidaExterior), i => i.GrupoCFOP);
                return Declaracoes.mapper.Map<IEnumerable<CodigoComboViewModel>>(combo);
            }
        }
        public async Task<IEnumerable<CodigoComboViewModel>> Combo(Entidade.Enum.TipoOperacaoCFOP tipoOperacao, Expression<Func<TabelaCFOP, object>> order = null)
        {
            var combo = await _TabelaCFOPService.GetAll(order, w => w.GrupoCFOP.TipoOperacaoCFOP == tipoOperacao, i => i.GrupoCFOP);
            return Declaracoes.mapper.Map<IEnumerable<CodigoComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
