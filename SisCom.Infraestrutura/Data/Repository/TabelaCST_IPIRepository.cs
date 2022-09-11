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
    public class TabelaCST_IPIRepository : Repository<TabelaCST_IPI>, ITabelaCST_IPIRepository
    {
        public TabelaCST_IPIRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaCST_IPI> GetById(Guid id)
        {
            return await Db.TabelaCST_IPIs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaCST_IPI>> GetAll()
        {
            return await Db.TabelaCST_IPIs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaCST_IPI>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaCST_IPIs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaCST_IPI>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaCST_IPI tabelaCST_IPI)
        {
            DbSet.Update(tabelaCST_IPI);
            await SaveChanges();
        }
    }
}
