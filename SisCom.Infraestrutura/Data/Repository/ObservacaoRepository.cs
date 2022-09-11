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
    public class ObservacaoRepository : Repository<Observacao>, IObservacaoRepository
    {
        public ObservacaoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<Observacao> GetById(Guid id)
        {
            return await Db.Observacaos.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Observacao>> GetAll()
        {
            return await Db.Observacaos.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<Observacao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.Observacaos
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<Observacao>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(Observacao observacao)
        {
            DbSet.Update(observacao);
            await SaveChanges();
        }
    }
}
