using Funcoes._Enum;
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
    public class NotaFiscalEntradaMercadoriaController : IDisposable
    {
        static NotaFiscalEntradaMercadoriaService notaFiscalEntradaMercadoriaService;
        static EstoqueLancamentoController estoqueLancamentoController;
        private readonly MeuDbContext meuDbContext;

        public NotaFiscalEntradaMercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.meuDbContext = meuDbContext;
            notaFiscalEntradaMercadoriaService = new NotaFiscalEntradaMercadoriaService(new NotaFiscalEntradaMercadoriaRepository(meuDbContext), notifier);
            estoqueLancamentoController = new EstoqueLancamentoController(meuDbContext, notifier);
        }
        public async Task<NotaFiscalEntradaMercadoriaViewModel> Adicionar(NotaFiscalEntradaMercadoriaViewModel notaFiscalEntradaMercadoriaViewModel)
        {
            var NotaFiscalEntradaMercadoria = Declaracoes.mapper.Map<NotaFiscalEntradaMercadoria>(notaFiscalEntradaMercadoriaViewModel);

            await notaFiscalEntradaMercadoriaService.Adicionar(NotaFiscalEntradaMercadoria);

            await estoqueLancamentoController.Adicionar(Declaracoes.sistema_almoxarifado,
                                                        notaFiscalEntradaMercadoriaViewModel.MercadoriaId.Value,
                                                        notaFiscalEntradaMercadoriaViewModel.UnidadeMedidaId.Value,
                                                        Entidade.Enum.TipoLancamentoEstoque.Movimentacao,
                                                        EntradaSaida.Entrada,
                                                        DateTime.Now,
                                                        notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria,
                                                        "Entrada de mercadoria"); ;

            return Declaracoes.mapper.Map<NotaFiscalEntradaMercadoriaViewModel>(NotaFiscalEntradaMercadoria);
        }
        public async Task<bool> Excluir(Guid Id)
        {
            await notaFiscalEntradaMercadoriaService.Excluir(Id);

            return true;
        }
        public async Task<bool> ExcluirTodos(Guid Id)
        {
            await notaFiscalEntradaMercadoriaService.ExcluirTodas(Id);

            return true;
        }
        public async Task<NotaFiscalEntradaMercadoriaViewModel> Atualizar(Guid id, NotaFiscalEntradaMercadoriaViewModel notaFiscalEntradaMercadoriaViewModel)
        {
            var notaFiscalEntradaMercadoriaExistente = await notaFiscalEntradaMercadoriaService.GetById(id);

            if (notaFiscalEntradaMercadoriaExistente.QuantidadeUnitaria - notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria > 0)
            {
                await estoqueLancamentoController.Adicionar(Declaracoes.sistema_almoxarifado,
                                                            notaFiscalEntradaMercadoriaViewModel.MercadoriaId.Value,
                                                            notaFiscalEntradaMercadoriaViewModel.UnidadeMedidaId.Value,
                                                            Entidade.Enum.TipoLancamentoEstoque.Movimentacao,
                                                            EntradaSaida.Saida,
                                                            DateTime.Now,
                                                            (notaFiscalEntradaMercadoriaExistente.QuantidadeUnitaria - notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria),
                                                            "Ajuste da entrada de mercadoria");
            }
            if (notaFiscalEntradaMercadoriaExistente.QuantidadeUnitaria - notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria < 0)
            {
                await estoqueLancamentoController.Adicionar(Declaracoes.sistema_almoxarifado,
                                                            notaFiscalEntradaMercadoriaViewModel.MercadoriaId.Value,
                                                            notaFiscalEntradaMercadoriaViewModel.UnidadeMedidaId.Value,
                                                            Entidade.Enum.TipoLancamentoEstoque.Movimentacao,
                                                            EntradaSaida.Entrada,
                                                            DateTime.Now,
                                                            notaFiscalEntradaMercadoriaViewModel.QuantidadeUnitaria - (notaFiscalEntradaMercadoriaExistente.QuantidadeUnitaria),
                                                            "Ajuste da entrada de mercadoria");
            }

            await notaFiscalEntradaMercadoriaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalEntradaMercadoria>(notaFiscalEntradaMercadoriaViewModel));

            return notaFiscalEntradaMercadoriaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await notaFiscalEntradaMercadoriaService.GetAll(null, null, i => i.NotaFiscalEntrada,
                                                                                          i => i.CFOP,
                                                                                          f => f.NotaFiscalEntrada.Fornecedor,
                                                                                          fe => fe.NotaFiscalEntrada.Fornecedor.Endereco.End_Cidade.Estado,
                                                                                          e => e.NotaFiscalEntrada.Empresa);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var pessoa = await notaFiscalEntradaMercadoriaService.GetAll(null,
                                                                          p => p.NotaFiscalEntradaId  == Id, 
                                                                          i => i.Mercadoria,
                                                                          i => i.NCM,
                                                                          i => i.UnidadeMedida,
                                                                          i => i.CFOP,
                                                                          i => i.CST);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalEntradaMercadoriaViewModel>>(pessoa);
        }
        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}