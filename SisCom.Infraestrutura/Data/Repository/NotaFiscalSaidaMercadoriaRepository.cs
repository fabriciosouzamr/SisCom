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
    public class NotaFiscalSaidaMercadoriaRepository : Repository<NotaFiscalSaidaMercadoria>, INotaFiscalSaidaMercadoriaRepository
    {
        public NotaFiscalSaidaMercadoriaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalSaidaMercadoria> GetById(Guid id)
        {
            return await Db.NotaFiscalSaidaMercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalSaidaMercadoria>> GetAll()
        {
            return await Db.NotaFiscalSaidaMercadorias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalSaidaMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalSaidaMercadorias
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalSaidaMercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalSaidaMercadoria notaFiscalSaidaMercadoria)
        {
            DbSet.Update(notaFiscalSaidaMercadoria);
            await SaveChanges();
        }
    }
}
