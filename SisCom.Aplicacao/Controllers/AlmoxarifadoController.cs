using Funcoes.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public class AlmoxarifadoController : IDisposable
    {
        static AlmoxarifadoService amoxarifadoService;
        private readonly MeuDbContext meuDbContext;

        public AlmoxarifadoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.meuDbContext = MeuDbContext;
            this.meuDbContext.Database.GetDbConnection();
            amoxarifadoService = new AlmoxarifadoService(new AlmoxarifadoRepository(this.meuDbContext), notifier);
        }
        public async Task<AlmoxarifadoViewModel> Adicionar(AlmoxarifadoViewModel AlmoxarifadoViewModel)
        {
            await amoxarifadoService.Adicionar(Declaracoes.mapper.Map<Almoxarifado>(AlmoxarifadoViewModel));
            return AlmoxarifadoViewModel;
        }
        public async Task<AlmoxarifadoViewModel> Atualizar(AlmoxarifadoViewModel AlmoxarifadoViewModel)
        {
            await amoxarifadoService.Atualizar(Declaracoes.mapper.Map<Almoxarifado>(AlmoxarifadoViewModel));
            return AlmoxarifadoViewModel;
        }
        public async Task Remover(Guid id)
        {
            await amoxarifadoService.Excluir(id);
            return;
        }
        public async Task<AlmoxarifadoViewModel> GetById(Guid id)
        {
            var obter = await amoxarifadoService.GetById(id);
            return Declaracoes.mapper.Map<AlmoxarifadoViewModel>(obter);
        }
        public async Task<IEnumerable<AlmoxarifadoViewModel>> ObterTodos(Expression<Func<Almoxarifado, object>> order = null)
        {
            var obterTodos = await amoxarifadoService.GetAll(order: order);
            return Declaracoes.mapper.Map<IEnumerable<AlmoxarifadoViewModel>>(obterTodos);
        }
        public async Task<IEnumerable<NomeComboViewModel>> Combo(Expression<Func<Almoxarifado, object>> order = null)
        {
            var combo = await amoxarifadoService.Combo(order);
            return Declaracoes.mapper.Map<IEnumerable<NomeComboViewModel>>(combo);
        }
        public void Dispose()
        {
            meuDbContext.Dispose();
        }
    }
}
