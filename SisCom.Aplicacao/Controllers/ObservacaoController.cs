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
    public class ObservacaoController : IDisposable
    {
        static ObservacaoService _observacaoService;
        private readonly MeuDbContext MeuDbContext;

        public ObservacaoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _observacaoService = new ObservacaoService(new ObservacaoRepository(this.MeuDbContext), notifier);
        }
        public async Task<ObservacaoViewModel> Adicionar(ObservacaoViewModel ObservacaoViewModel)
        {
            var observacao = Declaracoes.mapper.Map<Observacao>(ObservacaoViewModel);

            await _observacaoService.Adicionar(observacao);

            return Declaracoes.mapper.Map<ObservacaoViewModel>(observacao);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _observacaoService.Remover(Id);

            return true;
        }
        public async Task<ObservacaoViewModel> Atualizar(Guid id, ObservacaoViewModel ObservacaoViewModel)
        {
            await _observacaoService.Atualizar(Declaracoes.mapper.Map<Observacao>(ObservacaoViewModel));

            return ObservacaoViewModel;
        }
        public async Task<IEnumerable<ObservacaoViewModel>> ObterTodos()
        {
            var obterTodos = await _observacaoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<ObservacaoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<Observacao, object>> order = null)
        {
            var combo = await _observacaoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
