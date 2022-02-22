﻿using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class GrupoMercadoriaController
    {
        static GrupoMercadoriaService _grupoMercadoriaService;
        private readonly MeuDbContext MeuDbContext;

        public GrupoMercadoriaController(MeuDbContext MeuDbContext)
        {
            this.MeuDbContext = MeuDbContext;

            _grupoMercadoriaService = new GrupoMercadoriaService(new GrupoRepository(this.MeuDbContext), null);
        }

        public async Task<GrupoMercadoriaViewModel> Adicionar(GrupoMercadoriaViewModel grupoMercadoriaViewModel)
        {
            await _grupoMercadoriaService.Adicionar(Declaracoes.mapper.Map<GrupoMercadoria>(grupoMercadoriaViewModel));

            return grupoMercadoriaViewModel;
        }

        public async Task<GrupoMercadoriaViewModel> Atualizar(GrupoMercadoriaViewModel grupoMercadoriaViewModel)
        {
            await _grupoMercadoriaService.Atualizar(Declaracoes.mapper.Map<GrupoMercadoria>(grupoMercadoriaViewModel));

            return grupoMercadoriaViewModel;
        }

        public async Task Remover(Guid id)
        {
            await _grupoMercadoriaService.Remover(id);

            return;
        }

        public async Task<GrupoMercadoriaViewModel> GetById(Guid id)
        {
            var obter = await _grupoMercadoriaService.GetById(id);
            return Declaracoes.mapper.Map<GrupoMercadoriaViewModel>(obter);
        }

        public async Task<GrupoMercadoriaViewModel> GetByName(string nome)
        {
            var grupo = await _grupoMercadoriaService.Search(f => f.Nome == nome);
            return Declaracoes.mapper.Map<GrupoMercadoriaViewModel>(grupo);
        }

        public async Task<IEnumerable<GrupoMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _grupoMercadoriaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<GrupoMercadoriaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<GrupoMercadoriaComboViewModel>> Combo(Expression<Func<GrupoMercadoria, object>> order = null)
        {
            var combo = await _grupoMercadoriaService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<GrupoMercadoriaComboViewModel>>(combo);
        }
    }
}
