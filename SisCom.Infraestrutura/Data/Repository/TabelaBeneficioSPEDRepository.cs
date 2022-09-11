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
    public class TabelaBeneficioSPEDRepository : Repository<TabelaBeneficioSPED>, ITabelaBeneficioSPEDRepository
    {
        public TabelaBeneficioSPEDRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaBeneficioSPED> GetById(Guid id)
        {
            return await Db.TabelaBeneficioSPEDs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaBeneficioSPED>> GetAll()
        {
            return await Db.TabelaBeneficioSPEDs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaBeneficioSPED>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaBeneficioSPEDs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaBeneficioSPED>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaBeneficioSPED tabelaBeneficioSPED)
        {
            DbSet.Update(tabelaBeneficioSPED);
            await SaveChanges();
        }
    }
}
