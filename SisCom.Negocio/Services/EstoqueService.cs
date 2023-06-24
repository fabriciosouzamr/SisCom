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
    public class EstoqueService : BaseService<Estoque>, IEstoqueService
    {
        private readonly IEstoqueRepository estoqueRepository;

        public EstoqueService(IEstoqueRepository EstoqueRepository,
                              INotifier notificador) : base(notificador, EstoqueRepository)
        {
            estoqueRepository = EstoqueRepository;
        }

        public virtual async Task Adicionar(Estoque Estoque)
        {
            try
            {
                var exists = await estoqueRepository.Search(f => f.AlmoxarifadoId == Estoque.AlmoxarifadoId &&
                                                                 f.MercadoriaId == Estoque.MercadoriaId);

                if (exists.Any())
                {
                    Notify("Já existe uma Estoque para esse almoxarifado e produto informado.");
                    return;
                }

                await estoqueRepository.Insert(Estoque);
            }
            catch (Exception ex)
            {
                Notify("EstoqueService - Adicionar", ex);
            }
        }

        public virtual async Task Atualizar(Estoque Estoque)
        {
            try
            {
                var exists = await estoqueRepository.Search(f => f.AlmoxarifadoId == Estoque.AlmoxarifadoId &&
                                                                 f.MercadoriaId == Estoque.MercadoriaId &&
                                                                 f.Id != Estoque.Id);

                if (exists.Any())
                {
                    Notify("Já existe uma Estoque para esse almoxarifado e produto informado.");
                    return;
                }

                await estoqueRepository.Update(Estoque);
            }
            catch (Exception ex)
            {
                Notify("EstoqueService - Atualizar", ex);
            }
        }

        public async Task Excluir(Guid id)
        {
            await estoqueRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            estoqueRepository?.Dispose();
        }

        public Task<IPagedList<Estoque>> GetPagedList(FilteredPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Estoque>> Search(Expression<Func<Estoque, bool>> predicate, Expression<Func<Estoque, object>> order = null)
        {
            var Estoque = await estoqueRepository.Search(predicate, order);

            return Estoque;
        }

        public Task<List<Estoque>> Combo(Expression<Func<Estoque, object>> order = null)
        {
            throw new NotImplementedException();
        }
    }
}
