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
    public class TipoClienteController
    {
        static TipoClienteService _TipoClienteService;
        private readonly MeuDbContext MeuDbContext;

        public TipoClienteController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _TipoClienteService = new TipoClienteService(new TipoClienteRepository(this.MeuDbContext), notifier);
        }

        public async Task<TipoClienteViewModel> Adicionar(TipoClienteViewModel TipoClienteViewModel)
        {
            await _TipoClienteService.Adicionar(SisCom.Aplicacao.Classes.Declaracoes.mapper.Map<TipoCliente>(TipoClienteViewModel));

            return TipoClienteViewModel;
        }

        public async Task<TipoClienteViewModel> Atualizar(Guid id, TipoClienteViewModel TipoClienteViewModel)
        {
            await _TipoClienteService.Atualizar(SisCom.Aplicacao.Classes.Declaracoes.mapper.Map<TipoCliente>(TipoClienteViewModel));

            return TipoClienteViewModel;
        }

        public async Task<TipoClienteViewModel> Remover(Guid id)
        {
            await _TipoClienteService.Remover(id);

            return null;
        }

        public async Task<IEnumerable<TipoClienteViewModel>> ObterTodos(Expression<Func<TipoCliente, object>> order = null)
        {
            var obterTodos = await _TipoClienteService.GetAll(order);
            return SisCom.Aplicacao.Classes.Declaracoes.mapper.Map<IEnumerable<TipoClienteViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<TipoClienteComboViewModel>> Combo(Expression<Func<TipoCliente, object>> order = null)
        {
            var combo = await _TipoClienteService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<TipoClienteComboViewModel>>(combo);
        }

    }
}
