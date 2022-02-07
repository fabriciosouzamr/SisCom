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
    public class UnidadeMedidaRepository : Repository<UnidadeMedida>, IUnidadeMedidaRepository
    {
        public UnidadeMedidaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<UnidadeMedida> GetById(Guid id)
        {
            return await Db.UnidadeMedidas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<UnidadeMedida>> GetAll()
        {
            return await Db.UnidadeMedidas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<UnidadeMedida>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.UnidadeMedidas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<UnidadeMedida>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
