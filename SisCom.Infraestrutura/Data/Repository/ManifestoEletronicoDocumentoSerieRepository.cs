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
    public class ManifestoEletronicoDocumentoSerieRepository : Repository<ManifestoEletronicoDocumentoSerie>, IManifestoEletronicoDocumentoSerieRepository
    {
        public ManifestoEletronicoDocumentoSerieRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<ManifestoEletronicoDocumentoSerie> GetById(Guid id)
        {
            return await Db.ManifestoEletronicoDocumentoSeries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<ManifestoEletronicoDocumentoSerie>> GetAll()
        {
            return await Db.ManifestoEletronicoDocumentoSeries.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<ManifestoEletronicoDocumentoSerie>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.ManifestoEletronicoDocumentoSeries
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<ManifestoEletronicoDocumentoSerie>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(ManifestoEletronicoDocumentoSerie ManifestoEletronicoDocumentoSerie)
        {
            DbSet.Update(ManifestoEletronicoDocumentoSerie);
            await SaveChanges();
        }
    }
}
