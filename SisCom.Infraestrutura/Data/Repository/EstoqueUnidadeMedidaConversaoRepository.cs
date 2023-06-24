using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class EstoqueUnidadeMedidaConversaoRepository : Repository<EstoqueUnidadeMedidaConversao>, IEstoqueUnidadeMedidaConversaoRepository
    {
        public EstoqueUnidadeMedidaConversaoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<EstoqueUnidadeMedidaConversao> GetById(Guid id)
        {
            return await Db.EstoqueUnidadeMedidaConversaos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<EstoqueUnidadeMedidaConversao>> GetAll()
        {
            return await Db.EstoqueUnidadeMedidaConversaos.AsNoTracking().ToListAsync();
        }

        public override async Task Update(EstoqueUnidadeMedidaConversao estoqueUnidadeMedidaConversao)
        {
            DbSet.Update(estoqueUnidadeMedidaConversao);
            await SaveChanges();
        }
    }
}
