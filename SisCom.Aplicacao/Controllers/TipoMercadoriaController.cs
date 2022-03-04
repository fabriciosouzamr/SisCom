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
    public class TipoMercadoriaController
    {
        static TipoMercadoriaService _TipoMercadoriaService;
        private readonly MeuDbContext MeuDbContext;

        public TipoMercadoriaController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TipoMercadoriaService = new TipoMercadoriaService(new TipoMercadoriaRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<TipoMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _TipoMercadoriaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TipoMercadoriaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<TipoMercadoria, object>> order = null)
        {
            var combo = await _TipoMercadoriaService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
    }
}
