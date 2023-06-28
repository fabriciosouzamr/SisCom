using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class AlmoxarifadoRepository : Repository<Almoxarifado>, IAlmoxarifadoRepository
    {
        public AlmoxarifadoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Almoxarifado> GetById(Guid id)
        {
            return await Db.Almoxarifados.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Almoxarifado>> GetAll()
        {
            return await Db.Almoxarifados.AsNoTracking().ToListAsync();
        }

        public override async Task Update(Almoxarifado Almoxarifado)
        {
            DbSet.Update(Almoxarifado);
            await SaveChanges();
        }
    }

}
