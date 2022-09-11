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
    public class TabelaClasseEnquadramentoIPIRepository : Repository<TabelaClasseEnquadramentoIPI>, ITabelaClasseEnquadramentoIPIRepository
    {
        public TabelaClasseEnquadramentoIPIRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaClasseEnquadramentoIPI> GetById(Guid id)
        {
            return await Db.TabelaClasseEnquadramentoIPIs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaClasseEnquadramentoIPI>> GetAll()
        {
            return await Db.TabelaClasseEnquadramentoIPIs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaClasseEnquadramentoIPI>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaClasseEnquadramentoIPIs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaClasseEnquadramentoIPI>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaClasseEnquadramentoIPI tabelaClasseEnquadramentoIPI)
        {
            DbSet.Update(tabelaClasseEnquadramentoIPI);
            await SaveChanges();
        }
    }
}
