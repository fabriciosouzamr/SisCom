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
    public class TabelaSituacaoTributariaNFCeRepository : Repository<TabelaSituacaoTributariaNFCe>, ITabelaSituacaoTributariaNFCeRepository
    {
        public TabelaSituacaoTributariaNFCeRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaSituacaoTributariaNFCe> GetById(Guid id)
        {
            return await Db.TabelaSituacaoTributariaNFCes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaSituacaoTributariaNFCe>> GetAll()
        {
            return await Db.TabelaSituacaoTributariaNFCes.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaSituacaoTributariaNFCe>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaSituacaoTributariaNFCes
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaSituacaoTributariaNFCe>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
