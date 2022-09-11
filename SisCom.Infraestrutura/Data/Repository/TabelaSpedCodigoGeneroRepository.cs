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
    public class TabelaSpedCodigoGeneroRepository : Repository<TabelaSpedCodigoGenero>, ITabelaSpedCodigoGeneroRepository
    {
        public TabelaSpedCodigoGeneroRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaSpedCodigoGenero> GetById(Guid id)
        {
            return await Db.TabelaSpedCodigoGeneros.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaSpedCodigoGenero>> GetAll()
        {
            return await Db.TabelaSpedCodigoGeneros.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaSpedCodigoGenero>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaSpedCodigoGeneros
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaSpedCodigoGenero>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaSpedCodigoGenero tabelaSpedCodigoGenero)
        {
            DbSet.Update(tabelaSpedCodigoGenero);
            await SaveChanges();
        }
    }
}
