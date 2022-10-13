using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class NotaFiscalSaidaObservacaoController : IDisposable
    {
        static NotaFiscalSaidaObservacaoService _notaFiscalSaidaObservacaoService;
        private readonly MeuDbContext MeuDbContext;

        public NotaFiscalSaidaObservacaoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _notaFiscalSaidaObservacaoService = new NotaFiscalSaidaObservacaoService(new NotaFiscalSaidaObservacaoRepository(this.MeuDbContext), notifier);
        }
        public async Task<IEnumerable<NotaFiscalSaidaObservacaoViewModel>> ObterTodos()
        {
            var obterTodos = await _notaFiscalSaidaObservacaoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaObservacaoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<CodigoDescricaoComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaObservacao, object>> order = null)
        {
            var combo = await _notaFiscalSaidaObservacaoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<CodigoDescricaoComboViewModel>>(combo);
        }
        public async Task<NotaFiscalSaidaObservacaoViewModel> Adicionar(NotaFiscalSaidaObservacaoViewModel NotaFiscalSaidaObservacaoViewModel)
        {
            var NotaFiscalSaidaObservacao = Declaracoes.mapper.Map<NotaFiscalSaidaObservacao>(NotaFiscalSaidaObservacaoViewModel);

            await _notaFiscalSaidaObservacaoService.Adicionar(NotaFiscalSaidaObservacao);

            return Declaracoes.mapper.Map<NotaFiscalSaidaObservacaoViewModel>(NotaFiscalSaidaObservacao);
        }
        public async Task<NotaFiscalSaidaObservacaoViewModel> Atualizar(Guid id, NotaFiscalSaidaObservacaoViewModel NotaFiscalSaidaObservacaoViewModel)
        {
            await _notaFiscalSaidaObservacaoService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaObservacao>(NotaFiscalSaidaObservacaoViewModel));

            return NotaFiscalSaidaObservacaoViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaObservacaoViewModel>> PesquisarId(Guid Id)
        {
            var observacao = await _notaFiscalSaidaObservacaoService.GetAll(null, p => p.NotaFiscalSaidaId == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaObservacaoViewModel>>(observacao);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _notaFiscalSaidaObservacaoService.Excluir(Id);

            return true;
        }
        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
