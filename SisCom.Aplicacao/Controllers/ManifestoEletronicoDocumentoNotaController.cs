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
    public class ManifestoEletronicoDocumentoNotaController : IDisposable
    {
        static ManifestoEletronicoDocumentoNotaService _ManifestoEletronicoDocumentoNotaService;
        private readonly MeuDbContext meuDbContext;

        public ManifestoEletronicoDocumentoNotaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _ManifestoEletronicoDocumentoNotaService = new ManifestoEletronicoDocumentoNotaService(new ManifestoEletronicoDocumentoNotaRepository(meuDbContext), notifier);
        }
        public async Task<ManifestoEletronicoDocumentoNotaViewModel> Adicionar(ManifestoEletronicoDocumentoNotaViewModel ManifestoEletronicoDocumentoNotaViewModel)
        {
            var ManifestoEletronicoDocumentoNota = Declaracoes.mapper.Map<ManifestoEletronicoDocumentoNota>(ManifestoEletronicoDocumentoNotaViewModel);

            await _ManifestoEletronicoDocumentoNotaService.Adicionar(ManifestoEletronicoDocumentoNota);

            return Declaracoes.mapper.Map<ManifestoEletronicoDocumentoNotaViewModel>(ManifestoEletronicoDocumentoNota);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _ManifestoEletronicoDocumentoNotaService.Excluir(Id);

            return true;
        }
        public async Task<ManifestoEletronicoDocumentoNotaViewModel> Atualizar(Guid id, ManifestoEletronicoDocumentoNotaViewModel ManifestoEletronicoDocumentoNotaViewModel)
        {
            await _ManifestoEletronicoDocumentoNotaService.Atualizar(Declaracoes.mapper.Map<ManifestoEletronicoDocumentoNota>(ManifestoEletronicoDocumentoNotaViewModel));

            return ManifestoEletronicoDocumentoNotaViewModel;
        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoNotaViewModel>> ObterTodos()
        {
            var obterTodos = await _ManifestoEletronicoDocumentoNotaService.GetAll(null, null);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoNotaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoNotaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _ManifestoEletronicoDocumentoNotaService.GetAll(null, p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoNotaViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<ManifestoEletronicoDocumentoNota, object>> order = null)
        {
            var combo = await _ManifestoEletronicoDocumentoNotaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            //           meuDbContext.Dispose();
        }
    }
}
