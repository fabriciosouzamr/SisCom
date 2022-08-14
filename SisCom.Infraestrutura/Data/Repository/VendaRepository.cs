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
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Venda> GetById(Guid id)
        {
            return await Db.Vendas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Venda>> GetAll()
        {
            return await Db.Vendas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Venda>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Vendas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Observacao.Contains(parameters.Search)
                      )
                  ));;
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Venda>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
