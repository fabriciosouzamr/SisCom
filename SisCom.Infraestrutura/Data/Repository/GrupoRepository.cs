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
    public class GrupoRepository : Repository<GrupoMercadoria>, IGrupoMercadoriaRepository
    {
        public GrupoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<GrupoMercadoria> GetById(Guid id)
        {
            return await Db.GrupoMercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<GrupoMercadoria>> GetAll()
        {
            return await Db.GrupoMercadorias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<GrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.GrupoMercadorias
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<GrupoMercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
