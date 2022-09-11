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
    public class NotaFiscalEntradaMercadoriaRepository : Repository<NotaFiscalEntradaMercadoria>, INotaFiscalEntradaMercadoriaRepository
    {
        public NotaFiscalEntradaMercadoriaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalEntradaMercadoria> GetById(Guid id)
        {
            return await Db.NotaFiscalEntradaMercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalEntradaMercadoria>> GetAll()
        {
            return await Db.NotaFiscalEntradaMercadorias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalEntradaMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalEntradaMercadorias
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalEntradaMercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalEntradaMercadoria notaFiscalEntradaMercadoria)
        {
            DbSet.Update(notaFiscalEntradaMercadoria);
            await SaveChanges();
        }
    }
}
