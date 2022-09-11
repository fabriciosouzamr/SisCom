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
    public class FabricanteRepository : Repository<Fabricante>, IFabricanteRepository
    {
        public FabricanteRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Fabricante> GetById(Guid id)
        {
            return await Db.Fabricantes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Fabricante>> GetAll()
        {
            return await Db.Fabricantes.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Fabricante>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Fabricantes
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Fabricante>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(Fabricante fabricante)
        {
            DbSet.Update(fabricante);
            await SaveChanges();
        }
    }
}
