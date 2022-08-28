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
    public class MercadoriaImpostoEstadoController : IDisposable
    {
        static MercadoriaImpostoEstadoService _MercadoriaImpostoEstadoService;
        private readonly MeuDbContext MeuDbContext;

        public MercadoriaImpostoEstadoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _MercadoriaImpostoEstadoService = new MercadoriaImpostoEstadoService(new MercadoriaImpostoEstadoRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<MercadoriaImpostoEstadoViewModel>> ObterPorEstadosId(Guid estadoOrigemId, Guid estadoDestinoId)
        {
            var obterTodos = await _MercadoriaImpostoEstadoService.GetAll(null, p => p.EstadoOrigemId == estadoOrigemId && p.EstadoDestinoId == estadoDestinoId, i => i.Mercadoria);
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaImpostoEstadoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<MercadoriaImpostoEstadoViewModel>> ObterTodos()
        {
            var obterTodos = await _MercadoriaImpostoEstadoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaImpostoEstadoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<MercadoriaImpostoEstado, object>> order = null)
        {
            var combo = await _MercadoriaImpostoEstadoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
