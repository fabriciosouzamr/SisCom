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
    public class NotaFiscalEntradaFaturaRepository : Repository<NotaFiscalEntradaFatura>, INotaFiscalEntradaFaturaRepository
    {
        public NotaFiscalEntradaFaturaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalEntradaFatura> GetById(Guid id)
        {
            return await Db.NotaFiscalEntradaFaturas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalEntradaFatura>> GetAll()
        {
            return await Db.NotaFiscalEntradaFaturas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalEntradaFatura>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalEntradaFaturas
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalEntradaFatura>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalEntradaFatura notaFiscalEntradaFatura)
        {
            DbSet.Update(notaFiscalEntradaFatura);
            await SaveChanges();
        }
    }
}
