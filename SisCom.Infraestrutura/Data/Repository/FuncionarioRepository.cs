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
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Funcionario> GetById(Guid id)
        {
            return await Db.Funcionarios.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Funcionario>> GetAll()
        {
            return await Db.Funcionarios.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Funcionario>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Funcionarios
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Funcionario>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(Funcionario funcionario)
        {
            DbSet.Update(funcionario);
            await SaveChanges();
        }
    }
}
