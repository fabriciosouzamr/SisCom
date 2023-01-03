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
    public class ManifestoEletronicoDocumentoNotaRepository : Repository<ManifestoEletronicoDocumentoNota>, IManifestoEletronicoDocumentoNotaRepository
    {
        public ManifestoEletronicoDocumentoNotaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<ManifestoEletronicoDocumentoNota> GetById(Guid id)
        {
            return await Db.ManifestoEletronicoDocumentoNotas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<ManifestoEletronicoDocumentoNota>> GetAll()
        {
            return await Db.ManifestoEletronicoDocumentoNotas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<ManifestoEletronicoDocumentoNota>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.ManifestoEletronicoDocumentoNotas
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<ManifestoEletronicoDocumentoNota>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(ManifestoEletronicoDocumentoNota ManifestoEletronicoDocumentoNota)
        {
            DbSet.Update(ManifestoEletronicoDocumentoNota);
            await SaveChanges();
        }
    }
}
