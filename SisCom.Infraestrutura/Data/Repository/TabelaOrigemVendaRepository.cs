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
    public class TabelaOrigemVendaRepository : Repository<TabelaOrigemVenda>, ITabelaOrigemVendaRepository
    {
        public TabelaOrigemVendaRepository(MeuDbContext context) : base(context)
        {

        }

        public override async Task<TabelaOrigemVenda> GetById(Guid id)
        {
            return await Db.TabelaOrigemVendas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<TabelaOrigemVenda>> GetAll()
        {
            return await Db.TabelaOrigemVendas.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<TabelaOrigemVenda>> GetPagedList(FilteredPagedListParameters parameters)
        {
            var dadosFiltrados = Db.TabelaOrigemVendas
                .Where(p =>
                  (
                      parameters.Search == null ||
                      (
                          p.Descricao.Contains(parameters.Search)
                      )
                  ));
            dadosFiltrados = dadosFiltrados.OrderBy(parameters.Sort);

            return await PagedList<TabelaOrigemVenda>.ToPagedList(dadosFiltrados, parameters.CurrentPage, parameters.PageSize);
        }
    }
}