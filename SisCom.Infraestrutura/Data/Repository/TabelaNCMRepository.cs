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
    public class TabelaNCMRepository : Repository<TabelaNCM>, ITabelaNCMRepository
    {
        public TabelaNCMRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaNCM> GetById(Guid id)
        {
            return await Db.TabelaNCMs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaNCM>> GetAll()
        {
            return await Db.TabelaNCMs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaNCM>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaNCMs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaNCM>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
