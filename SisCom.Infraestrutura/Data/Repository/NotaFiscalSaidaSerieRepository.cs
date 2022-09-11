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
    public class NotaFiscalSaidaSerieRepository : Repository<NotaFiscalSaidaSerie>, INotaFiscalSaidaSerieRepository
    {
        public NotaFiscalSaidaSerieRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalSaidaSerie> GetById(Guid id)
        {
            return await Db.NotaFiscalSaidaSeries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalSaidaSerie>> GetAll()
        {
            return await Db.NotaFiscalSaidaSeries.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalSaidaSerie>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalSaidaSeries
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalSaidaSerie>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalSaidaSerie NotaFiscalSaidaSerie)
        {
            DbSet.Update(NotaFiscalSaidaSerie);
            await SaveChanges();
        }
    }
}
