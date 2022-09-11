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
    public class VendaMercadoriaRepository : Repository<VendaMercadoria>, IVendaMercadoriaRepository
    {
        public VendaMercadoriaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<VendaMercadoria> GetById(Guid id)
        {
            return await Db.VendaMercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<VendaMercadoria>> GetAll()
        {
            return await Db.VendaMercadorias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<VendaMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.VendaMercadorias
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Id.ToString().Contains(parameters.Search)
                      )
                  )); ;
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<VendaMercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(VendaMercadoria vendaMercadoria)
        {
            DbSet.Update(vendaMercadoria);
            await SaveChanges();
        }
    }
}