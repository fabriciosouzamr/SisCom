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
    public class NotaFiscalSaidaSerieController : IDisposable
    {
        static NotaFiscalSaidaSerieService _NotaFiscalSaidaSerieService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalSaidaSerieController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalSaidaSerieService = new NotaFiscalSaidaSerieService(new NotaFiscalSaidaSerieRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalSaidaSerieViewModel> Adicionar(NotaFiscalSaidaSerieViewModel NotaFiscalSaidaSerieViewModel)
        {
            var NotaFiscalSaidaSerie = Declaracoes.mapper.Map<NotaFiscalSaidaSerie>(NotaFiscalSaidaSerieViewModel);

            await _NotaFiscalSaidaSerieService.Adicionar(NotaFiscalSaidaSerie);

            return Declaracoes.mapper.Map<NotaFiscalSaidaSerieViewModel>(NotaFiscalSaidaSerie);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalSaidaSerieService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalSaidaSerieViewModel> Atualizar(Guid id, NotaFiscalSaidaSerieViewModel NotaFiscalSaidaSerieViewModel)
        {
            await _NotaFiscalSaidaSerieService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaSerie>(NotaFiscalSaidaSerieViewModel));

            return NotaFiscalSaidaSerieViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaSerieViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalSaidaSerieService.GetAll(null, null);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaSerieViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalSaidaSerieViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalSaidaSerieService.GetAll(null, p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaSerieViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NotaFiscalSaidaSerieViewModel>> PesquisarSerie(string Serie)
        {
            var serie = await _NotaFiscalSaidaSerieService.GetAll(null, p => p.Serie.Trim() == Serie.Trim());
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaSerieViewModel>>(serie);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaSerie, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaSerieService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}