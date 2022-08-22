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
    public class NotaFiscalSaidaMercadoriaController : IDisposable
    {
        static NotaFiscalSaidaMercadoriaService _NotaFiscalSaidaMercadoriaService;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalSaidaMercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _NotaFiscalSaidaMercadoriaService = new NotaFiscalSaidaMercadoriaService(new NotaFiscalSaidaMercadoriaRepository(meuDbContext), notifier);
        }
        public async Task<NotaFiscalSaidaMercadoriaViewModel> Adicionar(NotaFiscalSaidaMercadoriaViewModel NotaFiscalSaidaMercadoriaViewModel)
        {
            var NotaFiscalSaidaMercadoria = Declaracoes.mapper.Map<NotaFiscalSaidaMercadoria>(NotaFiscalSaidaMercadoriaViewModel);

            await _NotaFiscalSaidaMercadoriaService.Adicionar(NotaFiscalSaidaMercadoria);

            return Declaracoes.mapper.Map<NotaFiscalSaidaMercadoriaViewModel>(NotaFiscalSaidaMercadoria);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalSaidaMercadoriaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalSaidaMercadoriaViewModel> Atualizar(Guid id, NotaFiscalSaidaMercadoriaViewModel NotaFiscalSaidaMercadoriaViewModel)
        {
            await _NotaFiscalSaidaMercadoriaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaidaMercadoria>(NotaFiscalSaidaMercadoriaViewModel));

            return NotaFiscalSaidaMercadoriaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _NotaFiscalSaidaMercadoriaService.GetAll(null, null, i => i.NotaFiscalSaida,
                                                                                        i => i.TabelaCFOP,
                                                                                        f => f.NotaFiscalSaida.Cliente,
                                                                                        fe => fe.NotaFiscalSaida.Cliente.Endereco.End_Cidade.Estado,
                                                                                        e => e.NotaFiscalSaida.Empresa); ; ;
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _NotaFiscalSaidaMercadoriaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaMercadoriaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalSaidaMercadoria, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaMercadoriaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }

        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}