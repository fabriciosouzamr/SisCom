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
    public class TabelaSpedInformacaoAdicionalItemRepository : Repository<TabelaSpedInformacaoAdicionalItem>, ITabelaSpedInformacaoAdicionalItemRepository
    {
        public TabelaSpedInformacaoAdicionalItemRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaSpedInformacaoAdicionalItem> GetById(Guid id)
        {
            return await Db.TabelaSpedInformacaoAdicionalItems.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaSpedInformacaoAdicionalItem>> GetAll()
        {
            return await Db.TabelaSpedInformacaoAdicionalItems.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaSpedInformacaoAdicionalItem>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaSpedInformacaoAdicionalItems
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaSpedInformacaoAdicionalItem>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(TabelaSpedInformacaoAdicionalItem tabelaSpedInformacaoAdicionalItem)
        {
            DbSet.Update(tabelaSpedInformacaoAdicionalItem);
            await SaveChanges();
        }
    }
}
