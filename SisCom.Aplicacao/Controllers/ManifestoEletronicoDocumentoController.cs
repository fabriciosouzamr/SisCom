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
    public class ManifestoEletronicoDocumentoController : IDisposable
    {
        static ManifestoEletronicoDocumentoService _manifestoEletronicoDocumentoService;
        private readonly MeuDbContext meuDbContext;

        public ManifestoEletronicoDocumentoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _manifestoEletronicoDocumentoService = new ManifestoEletronicoDocumentoService(new ManifestoEletronicoDocumentoRepository(meuDbContext), notifier);
        }
        public async Task<ManifestoEletronicoDocumentoViewModel> Adicionar(ManifestoEletronicoDocumentoViewModel ManifestoEletronicoDocumentoViewModel)
        {
            var manifestoEletronicoDocumento = Declaracoes.mapper.Map<ManifestoEletronicoDocumento>(ManifestoEletronicoDocumentoViewModel);

            await _manifestoEletronicoDocumentoService.Adicionar(manifestoEletronicoDocumento);

            return Declaracoes.mapper.Map<ManifestoEletronicoDocumentoViewModel>(manifestoEletronicoDocumento);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _manifestoEletronicoDocumentoService.Excluir(Id);

            return true;
        }
        public async Task<ManifestoEletronicoDocumentoViewModel> Atualizar(Guid id, ManifestoEletronicoDocumentoViewModel ManifestoEletronicoDocumentoViewModel)
        {
            await _manifestoEletronicoDocumentoService.Atualizar(Declaracoes.mapper.Map<ManifestoEletronicoDocumento>(ManifestoEletronicoDocumentoViewModel));

            return ManifestoEletronicoDocumentoViewModel;
        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoViewModel>> ObterTodos()
        {
            var obterTodos = await _manifestoEletronicoDocumentoService.GetAll(null, null);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _manifestoEletronicoDocumentoService.GetAll(null, p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<ManifestoEletronicoDocumento, object>> order = null)
        {
            var combo = await _manifestoEletronicoDocumentoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            //           meuDbContext.Dispose();
        }
    }
}