﻿using Funcoes._Entity;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
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
    public class VendaController : IDisposable
    {
        static VendaService _vendaService;
        private readonly MeuDbContext MeuDbContext;

        public VendaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _vendaService = new VendaService(new VendaRepository(meuDbContext), notifier);
        }

        public async Task<VendaViewModel> Adicionar(VendaViewModel vendaViewModel)
        {
            var venda = Declaracoes.mapper.Map<Venda>(vendaViewModel);

            await _vendaService.Adicionar(venda);

            return Declaracoes.mapper.Map<VendaViewModel>(venda);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _vendaService.Excluir(Id);

            return true;
        }

        public async Task<VendaViewModel> Atualizar(Guid id, VendaViewModel VendaViewModal)
        {
            await _vendaService.Atualizar(Declaracoes.mapper.Map<Venda>(VendaViewModal));
            return VendaViewModal;
        }

        public async Task<IEnumerable<VendaViewModel>> ObterTodos(Expression<Func<Venda, object>> order = null)
        {
            var obterTodos = await _vendaService.GetAll(order, null, i => i.Cliente,
                                                                    i => i.Cliente.Endereco,
                                                                    i => i.Cliente.Endereco.End_Cidade,
                                                                    i => i.Cliente.Endereco.End_Cidade.Estado,
                                                                    i => i.Cliente.Endereco.End_Cidade.Estado.Pais,
                                                                    i => i.Vendedor);
            return Declaracoes.mapper.Map<IEnumerable<VendaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<VendaViewModel>> PesquisarId(Guid Id)
        {
            var venda = await _vendaService.GetAll(null, p => p.Id == Id, i => i.Cliente,
                                                                          i => i.Cliente.Endereco.End_Cidade,
                                                                          i => i.Cliente.Endereco.End_Cidade.Estado,
                                                                          i => i.Transportadora,
                                                                          i => i.Transportadora.Endereco.End_Cidade);
            return Declaracoes.mapper.Map<IEnumerable<VendaViewModel>>(venda);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}