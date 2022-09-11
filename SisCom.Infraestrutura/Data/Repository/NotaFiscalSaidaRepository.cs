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
    public class NotaFiscalSaidaRepository : Repository<NotaFiscalSaida>, INotaFiscalSaidaRepository
    {
        public NotaFiscalSaidaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalSaida> GetById(Guid id)
        {
            return await Db.NotaFiscalSaidas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalSaida>> GetAll()
        {
            return await Db.NotaFiscalSaidas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalSaida>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalSaidas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.CodigoChaveAcesso.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalSaida>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalSaida notaFiscalSaida)
        {
            DbSet.Update(notaFiscalSaida);
            await SaveChanges();
        }
    }
}
