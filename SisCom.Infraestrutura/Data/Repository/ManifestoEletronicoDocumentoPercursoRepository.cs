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
    public class ManifestoEletronicoDocumentoPercursoRepository : Repository<ManifestoEletronicoDocumentoPercurso>, IManifestoEletronicoDocumentoPercursoRepository
    {
        public ManifestoEletronicoDocumentoPercursoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<ManifestoEletronicoDocumentoPercurso> GetById(Guid id)
        {
            return await Db.ManifestoEletronicoDocumentoPercursos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<ManifestoEletronicoDocumentoPercurso>> GetAll()
        {
            return await Db.ManifestoEletronicoDocumentoPercursos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<ManifestoEletronicoDocumentoPercurso>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.ManifestoEletronicoDocumentoPercursos
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<ManifestoEletronicoDocumentoPercurso>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(ManifestoEletronicoDocumentoPercurso ManifestoEletronicoDocumentoPercurso)
        {
            DbSet.Update(ManifestoEletronicoDocumentoPercurso);
            await SaveChanges();
        }
    }
}
