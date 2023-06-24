using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace SisCom.Negocio.Services
{
    public class EstoqueLancamentoService : BaseService<EstoqueLancamento>, IEstoqueLancamentoService
    {
        private readonly IEstoqueLancamentoRepository estoqueLancamentoRepository;

        public EstoqueLancamentoService(IEstoqueLancamentoRepository EstoqueLancamentoRepository,
                                        INotifier notificador) : base(notificador, EstoqueLancamentoRepository)
        {
            estoqueLancamentoRepository = EstoqueLancamentoRepository;
        }

        public virtual async Task Adicionar(EstoqueLancamento EstoqueLancamento)
        {
            try
            {
                await estoqueLancamentoRepository.Insert(EstoqueLancamento);
            }
            catch (Exception ex)
            {
                Notify("EstoqueLancamentoService - Adicionar", ex);
            }
        }

        public virtual async Task Atualizar(EstoqueLancamento EstoqueLancamento)
        {
            try
            {
                await estoqueLancamentoRepository.Update(EstoqueLancamento);
            }
            catch (Exception ex)
            {
                Notify("EstoqueLancamentoService - Atualizar", ex);
            }
        }

        public async Task Excluir(Guid id)
        {
            await estoqueLancamentoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            estoqueLancamentoRepository?.Dispose();
        }

        public Task<IPagedList<EstoqueLancamento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<EstoqueLancamento>> Search(Expression<Func<EstoqueLancamento, bool>> predicate, Expression<Func<EstoqueLancamento, object>> order = null)
        {
            var EstoqueLancamento = await estoqueLancamentoRepository.Search(predicate, order);

            return EstoqueLancamento;
        }

        public Task<List<EstoqueLancamento>> Combo(Expression<Func<EstoqueLancamento, object>> order = null)
        {
            throw new NotImplementedException();
        }
    }
}
