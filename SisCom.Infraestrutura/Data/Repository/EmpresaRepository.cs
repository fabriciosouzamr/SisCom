using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SisCom.Infraestrutura.Data.Context;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Empresa> GetById(Guid id)
        {
            return await Db.Empresas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Empresa>> GetAll()
        {
            return await Db.Empresas.AsNoTracking().ToListAsync();
        }
    }
}
