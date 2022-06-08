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
    public class NotaFiscalEntradaRepository : Repository<NotaFiscalEntrada>, INotaFiscalEntradaRepository
    {
        public NotaFiscalEntradaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalEntrada> GetById(Guid id)
        {
            return await Db.NotaFiscalEntradas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalEntrada>> GetAll()
        {
            return await Db.NotaFiscalEntradas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalEntrada>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalEntradas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.CodigoChaveAcesso.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalEntrada>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
