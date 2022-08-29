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
    public class NotaFiscalSaidaPagamentoRepository : Repository<NotaFiscalSaidaPagamento>, INotaFiscalSaidaPagamentoRepository
    {
        public NotaFiscalSaidaPagamentoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalSaidaPagamento> GetById(Guid id)
        {
            return await Db.NotaFiscalSaidaPagamentos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalSaidaPagamento>> GetAll()
        {
            return await Db.NotaFiscalSaidaPagamentos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalSaidaPagamento>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalSaidaPagamentos
                .Where(p =>
                  (
                   parameters.Search == null /*|| ( p.Descricao.Contains(parameters.Search) )*/ ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalSaidaPagamento>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
