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
    public class TipoClienteRepository : Repository<TipoCliente>, ITipoClienteRepository
    {
        public TipoClienteRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TipoCliente> GetById(Guid id)
        {
            return await Db.TipoClientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TipoCliente>> GetAll()
        {
            return await Db.TipoClientes.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TipoCliente>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TipoClientes
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TipoCliente>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TipoCliente tipoCliente)
        {
            DbSet.Update(tipoCliente);
            await SaveChanges();
        }
    }
}
