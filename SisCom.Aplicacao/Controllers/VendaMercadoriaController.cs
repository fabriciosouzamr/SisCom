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
    public class VendaMercadoriaController : IDisposable
    {
        static VendaMercadoriaService _vendaMercadoriaService;
        private readonly MeuDbContext MeuDbContext;

        public VendaMercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _vendaMercadoriaService = new VendaMercadoriaService(new VendaMercadoriaRepository(meuDbContext), notifier);
        }

        public async Task<VendaMercadoriaViewModel> Adicionar(VendaMercadoriaViewModel vendaMercadoriaViewModel)
        {
            var vendaMercadoria = Declaracoes.mapper.Map<VendaMercadoria>(vendaMercadoriaViewModel);

            await _vendaMercadoriaService.Adicionar(vendaMercadoria);

            return Declaracoes.mapper.Map<VendaMercadoriaViewModel>(vendaMercadoria);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _vendaMercadoriaService.Excluir(Id);

            return true;
        }

        public async Task<VendaMercadoriaViewModel> Atualizar(Guid id, VendaMercadoriaViewModel vendaMercadoriaViewModal)
        {
            await _vendaMercadoriaService.Atualizar(Declaracoes.mapper.Map<VendaMercadoria>(vendaMercadoriaViewModal));

            return vendaMercadoriaViewModal;
        }

        public async Task<IEnumerable<VendaMercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _vendaMercadoriaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<VendaMercadoriaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<VendaMercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var vendaMercadoria = await _vendaMercadoriaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<VendaMercadoriaViewModel>>(vendaMercadoria);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}