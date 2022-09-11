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
    public class NaturezaOperacaoRepository : Repository<NaturezaOperacao>, INaturezaOperacaoRepository
    {
        public NaturezaOperacaoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NaturezaOperacao> GetById(Guid id)
        {
            return await Db.NaturezaOperacoes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NaturezaOperacao>> GetAll()
        {
            return await Db.NaturezaOperacoes.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NaturezaOperacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NaturezaOperacoes
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NaturezaOperacao>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NaturezaOperacao naturezaOperacao)
        {
            DbSet.Update(naturezaOperacao);
            await SaveChanges();
        }
    }
}
