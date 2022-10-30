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
        static MercadoriaImpostoEstadoService _mercadoriaImpostoEstadoService;
        private readonly MeuDbContext MeuDbContext;

        public MercadoriaImpostoEstadoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _mercadoriaImpostoEstadoService = new MercadoriaImpostoEstadoService(new MercadoriaImpostoEstadoRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<MercadoriaImpostoEstadoViewModel>> ObterPorEstadosId(Guid estadoOrigemId, Guid estadoDestinoId)
        {
            var obterTodos = await _mercadoriaImpostoEstadoService.GetAll(null, p => p.EstadoOrigemId == estadoOrigemId && p.EstadoDestinoId == estadoDestinoId, i => i.Mercadoria);
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaImpostoEstadoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<MercadoriaImpostoEstadoViewModel>> ObterTodos()
        {
            var obterTodos = await _mercadoriaImpostoEstadoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaImpostoEstadoViewModel>>(obterTodos);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
