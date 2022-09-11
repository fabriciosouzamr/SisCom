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
    public class TransportadoraRepository : Repository<Transportadora>, ITransportadoraRepository
    {
        public TransportadoraRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Transportadora> GetById(Guid id)
        {
            return await Db.Transportadoras.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Transportadora>> GetAll()
        {
            return await Db.Transportadoras.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Transportadora>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Transportadoras
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Transportadora>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(Transportadora transportadora)
        {
            DbSet.Update(transportadora);
            await SaveChanges();
        }
    }
}
