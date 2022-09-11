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
    public class MercadoriaImpostoEstadoRepository : Repository<MercadoriaImpostoEstado>, IMercadoriaImpostoEstadoRepository
    {
        public MercadoriaImpostoEstadoRepository(MeuDbContext context) : base(context)
        {

        }
        public override async Task<MercadoriaImpostoEstado> GetById(Guid id)
        {
            return await Db.MercadoriaImpostoEstados.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public override async Task<List<MercadoriaImpostoEstado>> GetAll()
        {
            return await Db.MercadoriaImpostoEstados.AsNoTracking().ToListAsync();
        }
        public async Task<IPagedList<MercadoriaImpostoEstado>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.MercadoriaImpostoEstados
                .Where(p =>
                  (
                      parameters.Search == null /*||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )*/
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<MercadoriaImpostoEstado>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }

        public override async Task Update(MercadoriaImpostoEstado mercadoriaImpostoEstado)
        {
            DbSet.Update(mercadoriaImpostoEstado);
            await SaveChanges();
        }
    }
}
