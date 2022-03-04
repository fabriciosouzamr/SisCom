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
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Pessoa> GetById(Guid id)
        {
            return await Db.Pessoas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Pessoa>> GetAll()
        {
            return await Db.Pessoas.AsNoTracking()
                .ToListAsync();
        }

        public override async Task Update(Pessoa pessoa)
        {
            DbSet.Update(pessoa);
            await SaveChanges();
        }

        public async Task<IPagedList<Pessoa>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Pessoas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Pessoa>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
