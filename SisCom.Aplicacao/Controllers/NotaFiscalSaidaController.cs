using Funcoes._Entity;
using Funcoes.Interfaces;
using NFe.Classes;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Infraestrutura.Migrations;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NotaFiscalSaida = SisCom.Entidade.Modelos.NotaFiscalSaida;

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
        public async Task<bool> Excluir(Guid Id)
        {
            await _NotaFiscalSaidaService.Excluir(Id);

            return true;
        }
        public async Task<NotaFiscalSaidaViewModel> Adicionar(NotaFiscalSaidaViewModel NotaFiscalSaidaViewModel)
        {
            var NotaFiscalSaida = Declaracoes.mapper.Map<NotaFiscalSaida>(NotaFiscalSaidaViewModel);

            await _NotaFiscalSaidaService.Adicionar(NotaFiscalSaida);

            return Declaracoes.mapper.Map<NotaFiscalSaidaViewModel>(NotaFiscalSaida);
        }
        public async Task<NotaFiscalSaidaViewModel> Atualizar(Guid id, NotaFiscalSaidaViewModel NotaFiscalSaidaViewModel)
        {
            NotaFiscalSaidaViewModel.Empresa = null;
            NotaFiscalSaidaViewModel.NaturezaOperacao = null;
            NotaFiscalSaidaViewModel.NotaFiscalFinalidade = null;
            NotaFiscalSaidaViewModel.Cliente = null;
            NotaFiscalSaidaViewModel.Cliente_Endereco.End_Cidade = null;
            NotaFiscalSaidaViewModel.Transportadora = null;
            NotaFiscalSaidaViewModel.Vendedor = null;
            NotaFiscalSaidaViewModel.Transportadora_CNPJ_CPF = null;
            NotaFiscalSaidaViewModel.Transportadora_UF = null;
            NotaFiscalSaidaViewModel.Venda = null;

            if (!String.IsNullOrWhiteSpace(NotaFiscalSaidaViewModel.Protocolo))
            {
                if (NotaFiscalSaidaViewModel.DataCancelamento != null)
                    NotaFiscalSaidaViewModel.Status = Entidade.Enum.NF_Status.Cancelado;
                else
                    NotaFiscalSaidaViewModel.Status = Entidade.Enum.NF_Status.Transmitida;
            }

            await _NotaFiscalSaidaService.Atualizar(Declaracoes.mapper.Map<NotaFiscalSaida>(NotaFiscalSaidaViewModel));

            return NotaFiscalSaidaViewModel;
        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> ObterTodos(Expression<Func<NotaFiscalSaida, bool>> predicate = null, Expression<Func<NotaFiscalSaida, object>> order = null)
        {
            var obterTodos = await _NotaFiscalSaidaService.GetAll(order, predicate, i => i.NotaFiscalFinalidade,
                                                                                    i => i.Cliente,
                                                                                    i => i.Cliente.Endereco,
                                                                                    i => i.Cliente.Endereco.End_Cidade,
                                                                                    i => i.Cliente.Endereco.End_Cidade.Estado,
                                                                                    i => i.Cliente.Endereco.End_Cidade.Estado.Pais,
                                                                                    i => i.Vendedor);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> Pesquisar(Expression<Func<NotaFiscalSaida, object>> order = null, 
                                                                           Expression<Func<NotaFiscalSaida, bool>> predicate = null, 
                                                                           params Expression<Func<NotaFiscalSaida, object>>[] includes)
        {
            var obterTodos = await _NotaFiscalSaidaService.GetAll(order, predicate, includes);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(obterTodos);

        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> PesquisarId(Guid Id)
        {
            var nota = await _NotaFiscalSaidaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(nota);
        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> PesquisarCompleto(Expression<Func<NotaFiscalSaida, bool>> predicate)
        {
            var nota = await _NotaFiscalSaidaService.GetAll(null, predicate, i => i.NaturezaOperacao,
                                                                             i => i.Empresa,
                                                                             i => i.Empresa.Endereco,
                                                                             i => i.Empresa.Endereco.End_Cidade,
                                                                             i => i.Empresa.Endereco.End_Cidade.Estado,
                                                                             i => i.Empresa.Endereco.End_Cidade.Estado.Pais,
                                                                             i => i.Cliente,
                                                                             i => i.Cliente.Endereco,
                                                                             i => i.Cliente.Endereco.End_Cidade,
                                                                             i => i.Cliente.Endereco.End_Cidade.Estado,
                                                                             i => i.Cliente.Endereco.End_Cidade.Estado.Pais,
                                                                             i => i.Cliente_Endereco.End_Cidade.Estado,
                                                                             i => i.Cliente_Endereco.End_Cidade.Estado.Pais,
                                                                             i => i.Transportadora,
                                                                             i => i.Transportadora.Endereco,
                                                                             i => i.Transportadora.Endereco.End_Cidade,
                                                                             i => i.Transportadora.Endereco.End_Cidade.Estado,
                                                                             i => i.Transportadora.Endereco.End_Cidade.Estado.Pais,
                                                                             i => i.NotaFiscalSaidaMercadoria, 
                                                                             i => i.NotaFiscalSaidaPagamento,
                                                                             i => i.NotaFiscalSaidaReferencia, 
                                                                             i => i.NotaFiscalSaidaObservacao,
                                                                             i => i.NotaFiscalFinalidade);
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(nota);
        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> PesquisarChave(String chave)
        {
            var notafiscal = await _NotaFiscalSaidaService.Search(p => p.CodigoChaveAcesso == chave.ToString());
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>(notafiscal);
        }
        public async Task<IEnumerable<NotaFiscalSaidaViewModel>> PesquisarNotaFiscal(String numeronotafiscal)
        {
            var notafiscal = await _NotaFiscalSaidaService.Search(p => p.NotaFiscal == numeronotafiscal.ToString().Trim());
            return Declaracoes.mapper.Map<IEnumerable<NotaFiscalSaidaViewModel>>((object)notafiscal);
        }
        public async Task<bool> PesquisarChaveExiste(String chave)
        {
            var notafiscal = await PesquisarChave(chave.ToString());
            return (notafiscal.Count() != 0);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<NotaFiscalSaida, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public async Task<IEnumerable<NF_ComboViewModel>> ComboDadosFiscais(Expression<Func<NotaFiscalSaida, object>> order = null)
        {
            var combo = await _NotaFiscalSaidaService.ComboSearch(w => w.CodigoChaveAcesso != "", order) ;
            return Declaracoes.mapper.Map<IEnumerable<NF_ComboViewModel>>(combo);
        }
        public void Dispose()
        {
 //           meuDbContext.Dispose();
        }
    }
}