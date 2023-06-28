using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class MercadoriaUnidadeMedidaConversaoRepository : Repository<MercadoriaUnidadeMedidaConversao>, IMercadoriaUnidadeMedidaConversaoRepository
    {
        public MercadoriaUnidadeMedidaConversaoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<MercadoriaUnidadeMedidaConversao> GetById(Guid id)
        {
            return await Db.MercadoriaUnidadeMedidaConversaos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<MercadoriaUnidadeMedidaConversao>> GetAll()
        {
            return await Db.MercadoriaUnidadeMedidaConversaos.AsNoTracking().ToListAsync();
        }

        public override async Task Update(MercadoriaUnidadeMedidaConversao mercadoriaUnidadeMedidaConversao)
        {
            DbSet.Update(mercadoriaUnidadeMedidaConversao);
            await SaveChanges();
        }
    }
}
