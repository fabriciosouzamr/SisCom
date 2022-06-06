﻿using SisCom.Entidade.Modelos;
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
    public class UnidadeMedidaConversaoRepository : Repository<UnidadeMedidaConversao>, IUnidadeMedidaConversaoRepository
    {
        public UnidadeMedidaConversaoRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<UnidadeMedidaConversao> GetById(Guid id)
        {
            return await Db.UnidadeMedidaConversoes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<UnidadeMedidaConversao>> GetAll()
        {
            return await Db.UnidadeMedidaConversoes.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<UnidadeMedidaConversao>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.UnidadeMedidaConversoes
                .Where(p =>
                  (
                      parameters.Search == null
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<UnidadeMedidaConversao>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}
