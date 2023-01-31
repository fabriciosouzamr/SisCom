using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class CondutorRepository : Repository<Condutor>, ICondutorRepository
    {
        public CondutorRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Condutor> GetById(Guid id)
        {
            return await Db.Condutores.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Condutor>> GetAll()
        {
            return await Db.Condutores.AsNoTracking().ToListAsync();
        }

        public override async Task Update(Condutor Condutor)
        {
            DbSet.Update(Condutor);
            await SaveChanges();
        }
    }
}
