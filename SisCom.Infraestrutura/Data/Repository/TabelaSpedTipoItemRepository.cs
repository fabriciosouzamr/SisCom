using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SisCom.Infraestrutura.Data.Context;
using Funcoes.PagedList;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class TabelaSpedTipoItemRepository : Repository<TabelaSpedTipoItem>, ITabelaSpedTipoItemRepository
    {
        public TabelaSpedTipoItemRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaSpedTipoItem> GetById(Guid id)
        {
            return await Db.TabelaSpedTipoItems.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaSpedTipoItem>> GetAll()
        {
            return await Db.TabelaSpedTipoItems.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaSpedTipoItem>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaSpedTipoItems
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaSpedTipoItem>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaSpedTipoItem tabelaSpedTipoItem)
        {
            DbSet.Update(tabelaSpedTipoItem);
            await SaveChanges();
        }
    }
}
