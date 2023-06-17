using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class EstoqueLancamentoController : IDisposable
    {
        static EstoqueLancamentoService _EstoqueLancamentoService;
        private readonly MeuDbContext MeuDbContext;

        public EstoqueLancamentoController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _EstoqueLancamentoService = new EstoqueLancamentoService(new EstoqueLancamentoRepository(this.MeuDbContext), notifier);
        }

        public async Task<EstoqueLancamentoViewModel> Adicionar(EstoqueLancamentoViewModel EstoqueLancamentoViewModel)
        {
            var EstoqueLancamento = Declaracoes.mapper.Map<EstoqueLancamento>(EstoqueLancamentoViewModel);

            await _EstoqueLancamentoService.Adicionar(EstoqueLancamento);

            return Declaracoes.mapper.Map<EstoqueLancamentoViewModel>(EstoqueLancamento);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _EstoqueLancamentoService.Excluir(Id);

            return true;
        }

        public async Task<EstoqueLancamentoViewModel> Atualizar(Guid id, EstoqueLancamentoViewModel EstoqueLancamentoViewModel)
        {
            await _EstoqueLancamentoService.Atualizar(Declaracoes.mapper.Map<EstoqueLancamento>(EstoqueLancamentoViewModel));

            return EstoqueLancamentoViewModel;
        }

        public async Task<EstoqueLancamentoViewModel> AtualizarNSU(Guid id, string sNSU)
        {
            var EstoqueLancamento = await GetById(id);

            await _EstoqueLancamentoService.Atualizar(Declaracoes.mapper.Map<EstoqueLancamento>(EstoqueLancamento));

            return EstoqueLancamento;
        }

        public async Task<EstoqueLancamentoViewModel> GetById(Guid id)
        {
            var obter = await _EstoqueLancamentoService.GetById(id, e => e.Estoque, c => c.Estoque.Almoxarifado, c => c.Estoque.Mercadoria);
            return Declaracoes.mapper.Map<EstoqueLancamentoViewModel>(obter);
        }

        public async Task<IEnumerable<EstoqueLancamentoViewModel>> ObterTodos()
        {
            var obterTodos = await _EstoqueLancamentoService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<EstoqueLancamentoViewModel>>(obterTodos);
        }
        public void Dispose()
        {
            _EstoqueLancamentoService.Dispose();
            MeuDbContext.Dispose();
        }
    }
}
