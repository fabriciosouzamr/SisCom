using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<VendaViewModel>> ObterTodos()
        {
            var obterTodos = await _vendaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<VendaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<VendaViewModel>> PesquisarId(Guid Id)
        {
            var venda = await _vendaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<VendaViewModel>>(venda);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}