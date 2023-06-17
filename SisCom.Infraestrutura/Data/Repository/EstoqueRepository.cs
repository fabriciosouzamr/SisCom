using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Estoque> GetById(Guid id)
        {
            return await Db.Estoques.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Estoque>> GetAll()
        {
            return await Db.Estoques.AsNoTracking().ToListAsync();
        }

        public override async Task Update(Estoque Estoque)
        {
            DbSet.Update(Estoque);
            await SaveChanges();
        }
    }
}
