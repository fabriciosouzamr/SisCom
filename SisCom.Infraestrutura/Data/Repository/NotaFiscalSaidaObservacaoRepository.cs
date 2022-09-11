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
    public class NotaFiscalSaidaObservacaoRepository : Repository<NotaFiscalSaidaObservacao>, INotaFiscalSaidaObservacaoRepository
    {
        public NotaFiscalSaidaObservacaoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<NotaFiscalSaidaObservacao> GetById(Guid id)
        {
            return await Db.NotaFiscalSaidaObservacaos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<NotaFiscalSaidaObservacao>> GetAll()
        {
            return await Db.NotaFiscalSaidaObservacaos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<NotaFiscalSaidaObservacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.NotaFiscalSaidaObservacaos
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<NotaFiscalSaidaObservacao>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(NotaFiscalSaidaObservacao notaFiscalSaidaObservacao)
        {
            DbSet.Update(notaFiscalSaidaObservacao);
            await SaveChanges();
        }
    }
}
