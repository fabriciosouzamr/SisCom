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
    public class TabelaCST_CSOSNRepository : Repository<TabelaCST_CSOSN>, ITabelaCST_CSOSNRepository
    {
        public TabelaCST_CSOSNRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaCST_CSOSN> GetById(Guid id)
        {
            return await Db.TabelaCST_CSOSNs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaCST_CSOSN>> GetAll()
        {
            return await Db.TabelaCST_CSOSNs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaCST_CSOSN>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaCST_CSOSNs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaCST_CSOSN>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaCST_CSOSN tabelaCST_CSOSN)
        {
            DbSet.Update(tabelaCST_CSOSN);
            await SaveChanges();
        }
    }
}
