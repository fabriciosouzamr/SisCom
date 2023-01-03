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
    public class ManifestoEletronicoDocumentoPercursoController : IDisposable
    {
        static ManifestoEletronicoDocumentoPercursoService _ManifestoEletronicoDocumentoPercursoService;
        private readonly MeuDbContext meuDbContext;

        public ManifestoEletronicoDocumentoPercursoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _ManifestoEletronicoDocumentoPercursoService = new ManifestoEletronicoDocumentoPercursoService(new ManifestoEletronicoDocumentoPercursoRepository(meuDbContext), notifier);
        }
        public async Task<ManifestoEletronicoDocumentoPercursoViewModel> Adicionar(ManifestoEletronicoDocumentoPercursoViewModel ManifestoEletronicoDocumentoPercursoViewModel)
        {
            var ManifestoEletronicoDocumentoPercurso = Declaracoes.mapper.Map<ManifestoEletronicoDocumentoPercurso>(ManifestoEletronicoDocumentoPercursoViewModel);

            await _ManifestoEletronicoDocumentoPercursoService.Adicionar(ManifestoEletronicoDocumentoPercurso);

            return Declaracoes.mapper.Map<ManifestoEletronicoDocumentoPercursoViewModel>(ManifestoEletronicoDocumentoPercurso);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _ManifestoEletronicoDocumentoPercursoService.Excluir(Id);

            return true;
        }
        public async Task<ManifestoEletronicoDocumentoPercursoViewModel> Atualizar(Guid id, ManifestoEletronicoDocumentoPercursoViewModel ManifestoEletronicoDocumentoPercursoViewModel)
        {
            await _ManifestoEletronicoDocumentoPercursoService.Atualizar(Declaracoes.mapper.Map<ManifestoEletronicoDocumentoPercurso>(ManifestoEletronicoDocumentoPercursoViewModel));

            return ManifestoEletronicoDocumentoPercursoViewModel;
        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoPercursoViewModel>> ObterTodos()
        {
            var obterTodos = await _ManifestoEletronicoDocumentoPercursoService.GetAll(null, null);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoPercursoViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoPercursoViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _ManifestoEletronicoDocumentoPercursoService.GetAll(null, p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoPercursoViewModel>>(pessoa);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<ManifestoEletronicoDocumentoPercurso, object>> order = null)
        {
            var combo = await _ManifestoEletronicoDocumentoPercursoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            //           meuDbContext.Dispose();
        }
    }
}
