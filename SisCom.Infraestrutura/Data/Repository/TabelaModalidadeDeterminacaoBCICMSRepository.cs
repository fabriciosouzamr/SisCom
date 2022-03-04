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
    public class TabelaModalidadeDeterminacaoBCICMSRepository : Repository<TabelaModalidadeDeterminacaoBCICMS>, ITabelaModalidadeDeterminacaoBCICMSRepository
    {
        public TabelaModalidadeDeterminacaoBCICMSRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaModalidadeDeterminacaoBCICMS> GetById(Guid id)
        {
            return await Db.TabelaModalidadeDeterminacaoBCICMSs.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaModalidadeDeterminacaoBCICMS>> GetAll()
        {
            return await Db.TabelaModalidadeDeterminacaoBCICMSs.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaModalidadeDeterminacaoBCICMS>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaModalidadeDeterminacaoBCICMSs
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaModalidadeDeterminacaoBCICMS>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
