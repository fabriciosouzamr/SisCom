using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SisCom.Infraestrutura.Data.Context;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class FiscalEstadoIcmsRepository : Repository<FiscalEstadoIcms>, IFiscalEstadoIcmsRepository
    {
        public FiscalEstadoIcmsRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<FiscalEstadoIcms> GetById(Guid id)
        {
            return await Db.FiscalEstadoIcmses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<FiscalEstadoIcms>> GetAll()
        {
            return await Db.FiscalEstadoIcmses.AsNoTracking().ToListAsync();
        }

        public override async Task Update(FiscalEstadoIcms FiscalEstadoIcms)
        {
            DbSet.Update(FiscalEstadoIcms);
            await SaveChanges();
        }
    }
}
