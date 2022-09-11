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
    public class TabelaCFOPRepository : Repository<TabelaCFOP>, ITabelaCFOPRepository
    {
        public TabelaCFOPRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaCFOP> GetById(Guid id)
        {
            return await Db.TabelaCFOPs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaCFOP>> GetAll()
        {
            return await Db.TabelaCFOPs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaCFOP>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaCFOPs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaCFOP>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaCFOP tabelaCFOP)
        {
            DbSet.Update(tabelaCFOP);
            await SaveChanges();
        }
    }
}
