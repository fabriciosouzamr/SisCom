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
    public class SubGrupoRepository : Repository<SubGrupoMercadoria>, ISubGrupoMercadoriaRepository
    {
        public SubGrupoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<SubGrupoMercadoria> GetById(Guid id)
        {
            return await Db.SubGrupoMercadorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<SubGrupoMercadoria>> GetAll()
        {
            return await Db.SubGrupoMercadorias.AsNoTracking()
                .ToListAsync();
        }

        public async Task<IPagedList<SubGrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.SubGrupoMercadorias
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<SubGrupoMercadoria>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
