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
    public class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Pais> GetById(Guid id)
        {
            return await Db.Paises.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Pais>> GetAll()
        {
            return await Db.Paises.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Pais>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Paises
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Pais>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
