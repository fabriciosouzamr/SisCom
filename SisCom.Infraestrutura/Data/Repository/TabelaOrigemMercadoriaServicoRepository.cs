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
    public class TabelaOrigemMercadoriaServicoRepository : Repository<TabelaOrigemMercadoriaServico>, ITabelaOrigemMercadoriaServicoRepository
    {
        public TabelaOrigemMercadoriaServicoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaOrigemMercadoriaServico> GetById(Guid id)
        {
            return await Db.TabelaOrigemMercadoriaServicos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaOrigemMercadoriaServico>> GetAll()
        {
            return await Db.TabelaOrigemMercadoriaServicos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaOrigemMercadoriaServico>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaOrigemMercadoriaServicos
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaOrigemMercadoriaServico>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaOrigemMercadoriaServico tabelaOrigemMercadoriaServico)
        {
            DbSet.Update(tabelaOrigemMercadoriaServico);
            await SaveChanges();
        }
    }
}
