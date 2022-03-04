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
    public class TipoServicoFiscalRepository : Repository<TipoServicoFiscal>, ITipoServicoFiscalRepository
    {
        public TipoServicoFiscalRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TipoServicoFiscal> GetById(Guid id)
        {
            return await Db.TipoServicoFiscais.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TipoServicoFiscal>> GetAll()
        {
            return await Db.TipoServicoFiscais.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TipoServicoFiscal>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TipoServicoFiscais
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TipoServicoFiscal>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
