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
    public class TransportadoraController : IDisposable
    {

        static TransportadoraService _transportadoraService;
        private readonly MeuDbContext MeuDbContext;

        public TransportadoraController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _transportadoraService = new TransportadoraService(new TransportadoraRepository(meuDbContext), notifier);
        }
        public async Task<TransportadoraViewModel> Adicionar(TransportadoraViewModel transportadoraViewModel)
        {
            var transportadora = Declaracoes.mapper.Map<Transportadora>(transportadoraViewModel);

            await _transportadoraService.Adicionar(transportadora);

            return Declaracoes.mapper.Map<TransportadoraViewModel>(transportadora);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _transportadoraService.Excluir(Id);

            return true;
        }
        public async Task<TransportadoraViewModel> Atualizar(Guid id, TransportadoraViewModel transportadoraViewModel)
        {
            await _transportadoraService.Atualizar(Declaracoes.mapper.Map<Transportadora>(transportadoraViewModel));

            return transportadoraViewModel;
        }
        public async Task<IEnumerable<TransportadoraViewModel>> ObterTodos()
        {
            var obterTodos = await _transportadoraService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<TransportadoraViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<TransportadoraViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _transportadoraService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<TransportadoraViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<Transportadora, object>> order = null)
        {
            var combo = await _transportadoraService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            _transportadoraService.Dispose();
            MeuDbContext.Dispose();
        }

    }
}