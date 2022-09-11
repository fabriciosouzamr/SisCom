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
    public class VinculoFiscalRepository : Repository<VinculoFiscal>, IVinculoFiscalRepository
    {
        public VinculoFiscalRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<VinculoFiscal> GetById(Guid id)
        {
            return await Db.VinculoFiscais.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<VinculoFiscal>> GetAll()
        {
            return await Db.VinculoFiscais.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<VinculoFiscal>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.VinculoFiscais
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<VinculoFiscal>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(VinculoFiscal vinculoFiscal)
        {
            DbSet.Update(vinculoFiscal);
            await SaveChanges();
        }
    }
}
