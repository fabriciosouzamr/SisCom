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
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class ManifestoEletronicoDocumentoSerieController : IDisposable
    {
        static ManifestoEletronicoDocumentoSerieService _manifestoEletronicoDocumentoSerieService;
        private readonly MeuDbContext meuDbContext;

        public ManifestoEletronicoDocumentoSerieController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            _manifestoEletronicoDocumentoSerieService = new ManifestoEletronicoDocumentoSerieService(new ManifestoEletronicoDocumentoSerieRepository(meuDbContext), notifier);
        }
        public async Task<ManifestoEletronicoDocumentoSerieViewModel> Adicionar(ManifestoEletronicoDocumentoSerieViewModel ManifestoEletronicoDocumentoSerieViewModel)
        {
            var ManifestoEletronicoDocumentoSerie = Declaracoes.mapper.Map<ManifestoEletronicoDocumentoSerie>(ManifestoEletronicoDocumentoSerieViewModel);

            await _manifestoEletronicoDocumentoSerieService.Adicionar(ManifestoEletronicoDocumentoSerie);

            return Declaracoes.mapper.Map<ManifestoEletronicoDocumentoSerieViewModel>(ManifestoEletronicoDocumentoSerie);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await _manifestoEletronicoDocumentoSerieService.Excluir(Id);

            return true;
        }
        public async Task<ManifestoEletronicoDocumentoSerieViewModel> Atualizar(Guid id, ManifestoEletronicoDocumentoSerieViewModel ManifestoEletronicoDocumentoSerieViewModel)
        {
            await _manifestoEletronicoDocumentoSerieService.Atualizar(Declaracoes.mapper.Map<ManifestoEletronicoDocumentoSerie>(ManifestoEletronicoDocumentoSerieViewModel));

            return ManifestoEletronicoDocumentoSerieViewModel;
        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoSerieViewModel>> ObterTodos()
        {
            var obterTodos = await _manifestoEletronicoDocumentoSerieService.GetAll(null, null);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoSerieViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoSerieViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await _manifestoEletronicoDocumentoSerieService.GetAll(null, p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoSerieViewModel>>(pessoa);
        }
        public async Task<IEnumerable<ManifestoEletronicoDocumentoSerieViewModel>> PesquisarSerie(string Serie)
        {
            var serie = await _manifestoEletronicoDocumentoSerieService.GetAll(null, p => p.Serie.Trim() == Serie.Trim());
            return Declaracoes.mapper.Map<IEnumerable<ManifestoEletronicoDocumentoSerieViewModel>>(serie);
        }
        public async Task<String> NovoNumeroNotaFiscal(string Serie)
        {
            var series = await _manifestoEletronicoDocumentoSerieService.GetAll(null, p => p.Serie.Trim() == Serie.Trim());
            string notaFiscal = "";

            if (series.Any())
            {
                var serie = series.FirstOrDefault();

                notaFiscal = serie.UltimoNumeroManifestoEletronicoDocumento;

                if (String.IsNullOrEmpty(notaFiscal))
                { notaFiscal = "1"; }
                else
                { notaFiscal = (Convert.ToInt16(notaFiscal) + 1).ToString(); }

                serie.UltimoNumeroManifestoEletronicoDocumento = notaFiscal;

                await _manifestoEletronicoDocumentoSerieService.Atualizar(serie);
            }

            return notaFiscal;
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<ManifestoEletronicoDocumentoSerie, object>> order = null)
        {
            var combo = await _manifestoEletronicoDocumentoSerieService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            //           meuDbContext.Dispose();
        }
    }
}
