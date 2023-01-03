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
    public class ManifestoEletronicoDocumentoRepository : Repository<ManifestoEletronicoDocumento>, IManifestoEletronicoDocumentoRepository
    {
        public ManifestoEletronicoDocumentoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<ManifestoEletronicoDocumento> GetById(Guid id)
        {
            return await Db.ManifestoEletronicoDocumentos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<ManifestoEletronicoDocumento>> GetAll()
        {
            return await Db.ManifestoEletronicoDocumentos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<ManifestoEletronicoDocumento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.ManifestoEletronicoDocumentos
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<ManifestoEletronicoDocumento>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(ManifestoEletronicoDocumento ManifestoEletronicoDocumento)
        {
            DbSet.Update(ManifestoEletronicoDocumento);
            await SaveChanges();
        }
    }
}
