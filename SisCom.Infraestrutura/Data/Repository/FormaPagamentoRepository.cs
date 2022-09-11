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
    public class FormaPagamentoRepository : Repository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<FormaPagamento> GetById(Guid id)
        {
            return await Db.FormaPagamentos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<FormaPagamento>> GetAll()
        {
            return await Db.FormaPagamentos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<FormaPagamento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.FormaPagamentos
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Nome.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<FormaPagamento>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(FormaPagamento formaPagamento)
        {
            DbSet.Update(formaPagamento);
            await SaveChanges();
        }
    }
}
