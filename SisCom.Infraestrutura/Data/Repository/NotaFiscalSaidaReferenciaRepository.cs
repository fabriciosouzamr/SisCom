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
    public class NotaFiscalSaidaReferenciaRepository : Repository<NotaFiscalSaidaReferencia>, INotaFiscalSaidaReferenciaRepository
    {
        public NotaFiscalSaidaReferenciaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalSaidaReferencia> GetById(Guid id)
        {
            return await Db.NotaFiscalSaidaReferencias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalSaidaReferencia>> GetAll()
        {
            return await Db.NotaFiscalSaidaReferencias.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalSaidaReferencia>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalSaidaReferencias
                .Where(p =>
                  (
                      parameters.Search == null /*|| ( p.Descricao.Contains(parameters.Search) )*/
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalSaidaReferencia>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
