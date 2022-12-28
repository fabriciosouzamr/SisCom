using Funcoes.PagedList;
using Microsoft.EntityFrameworkCore;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Repository
{
    public class VeiculoPlacaRepository : Repository<VeiculoPlaca>, IVeiculoPlacaRepository
    {
        public VeiculoPlacaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<VeiculoPlaca> GetById(Guid id)
        {
            return await Db.VeiculoPlacas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<VeiculoPlaca>> GetAll()
        {
            return await Db.VeiculoPlacas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<VeiculoPlaca>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.VeiculoPlacas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.NumeroPlaca.Contains(parameters.Search)
                      )
                  ));

            return await PagedList<VeiculoPlaca>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(VeiculoPlaca VeiculoPlaca)
        {
            DbSet.Update(VeiculoPlaca);
            await SaveChanges();
        }
    }
}