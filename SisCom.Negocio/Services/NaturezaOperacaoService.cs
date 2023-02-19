using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class NaturezaOperacaoService : BaseService<NaturezaOperacao>, INaturezaOperacaoService
    {
        private readonly INaturezaOperacaoRepository _NaturezaOperacaoRepository;

        public NaturezaOperacaoService(INaturezaOperacaoRepository NaturezaOperacaoRepository,
                                 INotifier notificador) : base(notificador, NaturezaOperacaoRepository)
        {
            _NaturezaOperacaoRepository = NaturezaOperacaoRepository;
        }

        public Task<IPagedList<NaturezaOperacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _NaturezaOperacaoRepository.GetPagedList(f =>
            (
                parameters.Search == null), parameters);
        }
        public Task<List<NaturezaOperacao>> GetAll(Expression<Func<NaturezaOperacao, object>> order = null, params Expression<Func<NaturezaOperacao, object>>[] includes)
        {
            var getAll = _NaturezaOperacaoRepository.GetAll(order, includes);
            return getAll;
        }

        public override void Dispose()
        {
            _NaturezaOperacaoRepository?.Dispose();
        }

        public async Task Adicionar(NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                var _NaturezaOperacao = await _NaturezaOperacaoRepository.Search(f => f.Nome == NaturezaOperacao.Nome);

                if (_NaturezaOperacao.Any())
                {
                    Notify("Já existe uma Natureza de Operação com esse nome informado.");
                    return;
                }

                await _NaturezaOperacaoRepository.Insert(NaturezaOperacao);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Atualizar(NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                var _NotaFiscalSaida = await _NaturezaOperacaoRepository.Search(f => (f.Nome == NaturezaOperacao.Nome) && (f.Id != NaturezaOperacao.Id));

                await _NaturezaOperacaoRepository.Update(NaturezaOperacao);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
