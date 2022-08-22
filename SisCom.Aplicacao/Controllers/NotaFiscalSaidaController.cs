using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class NotaFiscalSaidaController : IDisposable
    {
        static NotaFiscalSaidaService _NotaFiscalSaidaService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalSaidaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalSaidaService = new NotaFiscalSaidaService(new NotaFiscalSaidaRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalSaidaViewModel> Adicionar(NotaFiscalSaidaViewModel NotaFiscalSaidaViewModel)
        {
            var NotaFiscalSaida = Declaracoes.mapper.Map<NotaFiscalSaida>(NotaFiscalSaidaViewModel);

            await _NotaFiscalSaidaService.Adicionar(NotaFiscalSaida);

            return Declaracoes.mapper.Map<NotaFiscalSaidaViewModel>(NotaFiscalSaida);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalSaidaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalSaidaViewModel> Atualizar(Guid id, NotaFiscalSaidaViewModel NotaFiscalSaidaViewModel)
        {
            await _NotaFiscalSaidaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaida>(NotaFiscalSaidaViewModel));

            return NotaFiscalSaidaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalSaidaService.GetAll(null, null, i => i.NumeroNotaFiscalSaida);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalSaidaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> PesquisarChave(String Chave)
        {
            var pessoa = await _NotaFiscalSaidaService.Search(p => p.CodigoChaveAcesso == Chave.ToString());
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(pessoa);
        }
        public async Task<bool> PesquisarChaveExiste(String Chave)
        {
            var pessoa = await PesquisarChave(Chave.ToString());
            return (pessoa.Count() != 0);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalSaida, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            meuDbContext.Dispose();
        }

    }
}