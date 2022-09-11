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
    public class MercadoriaRepository : Repository<Mercadoria>, IMercadoriaRepository
    {
        public MercadoriaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Mercadoria> GetById(Guid id)
        {
            return await Db.Mercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Mercadoria>> GetAll()
        {
            return await Db.Mercadorias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Mercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Mercadorias
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Mercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(Mercadoria mercadoria)
        {
            DbSet.Update(mercadoria);
            await SaveChanges();
        }
    }
}
