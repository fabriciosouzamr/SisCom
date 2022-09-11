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
    public class NotaFiscalFinalidadeRepository : Repository<NotaFiscalFinalidade>, INotaFiscalFinalidadeRepository
    {
        public NotaFiscalFinalidadeRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalFinalidade> GetById(Guid id)
        {
            return await Db.NotaFiscalFinalidades.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalFinalidade>> GetAll()
        {
            return await Db.NotaFiscalFinalidades.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalFinalidade>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalFinalidades
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalFinalidade>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalFinalidade notaFiscalFinalidade)
        {
            DbSet.Update(notaFiscalFinalidade);
            await SaveChanges();
        }
    }
}