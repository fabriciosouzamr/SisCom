using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class EstoqueLancamentoRepository : Repository<EstoqueLancamento>, IEstoqueLancamentoRepository
    {
        public EstoqueLancamentoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<EstoqueLancamento> GetById(Guid id)
        {
            return await Db.EstoqueLancamentos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<EstoqueLancamento>> GetAll()
        {
            return await Db.EstoqueLancamentos.AsNoTracking().ToListAsync();
        }

        public override async Task Update(EstoqueLancamento EstoqueLancamento)
        {
            DbSet.Update(EstoqueLancamento);
            await SaveChanges();
        }
    }
}
