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
    public class TabelaCodigoEnquadramentoIPIRepository : Repository<TabelaCodigoEnquadramentoIPI>, ITabelaCodigoEnquadramentoIPIRepository
    {
        public TabelaCodigoEnquadramentoIPIRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaCodigoEnquadramentoIPI> GetById(Guid id)
        {
            return await Db.TabelaCodigoEnquadramentoIPIs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaCodigoEnquadramentoIPI>> GetAll()
        {
            return await Db.TabelaCodigoEnquadramentoIPIs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaCodigoEnquadramentoIPI>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaCodigoEnquadramentoIPIs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaCodigoEnquadramentoIPI>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaCodigoEnquadramentoIPI tabelaCodigoEnquadramentoIPI)
        {
            DbSet.Update(tabelaCodigoEnquadramentoIPI);
            await SaveChanges();
        }
    }
}
