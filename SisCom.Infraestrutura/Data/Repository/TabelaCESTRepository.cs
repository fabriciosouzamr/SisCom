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
    public class TabelaCESTRepository : Repository<TabelaCEST>, ITabelaCESTRepository
    {
        public TabelaCESTRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaCEST> GetById(Guid id)
        {
            return await Db.TabelaCESTs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaCEST>> GetAll()
        {
            return await Db.TabelaCESTs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaCEST>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaCESTs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaCEST>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaCEST tabelaCEST)
        {
            DbSet.Update(tabelaCEST);
            await SaveChanges();
        }
    }
}
