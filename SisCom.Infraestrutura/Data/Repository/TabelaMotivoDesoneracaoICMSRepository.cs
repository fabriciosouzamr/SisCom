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
    public class TabelaMotivoDesoneracaoICMSRepository : Repository<TabelaMotivoDesoneracaoICMS>, ITabelaMotivoDesoneracaoICMSRepository
    {
        public TabelaMotivoDesoneracaoICMSRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaMotivoDesoneracaoICMS> GetById(Guid id)
        {
            return await Db.TabelaMotivoDesoneracaoICMSs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaMotivoDesoneracaoICMS>> GetAll()
        {
            return await Db.TabelaMotivoDesoneracaoICMSs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaMotivoDesoneracaoICMS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaMotivoDesoneracaoICMSs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaMotivoDesoneracaoICMS>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
