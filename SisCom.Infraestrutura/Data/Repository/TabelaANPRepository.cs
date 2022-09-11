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
    public class TabelaANPRepository : Repository<TabelaANP>, ITabelaANPRepository
    {
        public TabelaANPRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaANP> GetById(Guid id)
        {
            return await Db.TabelaANPs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaANP>> GetAll()
        {
            return await Db.TabelaANPs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaANP>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaANPs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaANP>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaANP tabelaANP)
        {
            DbSet.Update(tabelaANP);
            await SaveChanges();
        }
    }
}
