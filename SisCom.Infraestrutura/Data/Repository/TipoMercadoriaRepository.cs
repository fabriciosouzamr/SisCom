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
    public class TipoMercadoriaRepository : Repository<TipoMercadoria>, ITipoMercadoriaRepository
    {
        public TipoMercadoriaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TipoMercadoria> GetById(Guid id)
        {
            return await Db.TipoMercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TipoMercadoria>> GetAll()
        {
            return await Db.TipoMercadorias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TipoMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TipoMercadorias
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TipoMercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TipoMercadoria tipoMercadoria)
        {
            DbSet.Update(tipoMercadoria);
            await SaveChanges();
        }
    }
}
