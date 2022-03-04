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
    public class TabelaNaturezaReceita_CTS_PIS_COFINSRepository : Repository<TabelaNaturezaReceita_CTS_PIS_COFINS>, ITabelaNaturezaReceita_CTS_PIS_COFINSRepository
    {
        public TabelaNaturezaReceita_CTS_PIS_COFINSRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaNaturezaReceita_CTS_PIS_COFINS> GetById(Guid id)
        {
            return await Db.TabelaNaturezaReceita_CTS_PIS_COFINSs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaNaturezaReceita_CTS_PIS_COFINS>> GetAll()
        {
            return await Db.TabelaNaturezaReceita_CTS_PIS_COFINSs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaNaturezaReceita_CTS_PIS_COFINS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaNaturezaReceita_CTS_PIS_COFINSs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaNaturezaReceita_CTS_PIS_COFINS>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
