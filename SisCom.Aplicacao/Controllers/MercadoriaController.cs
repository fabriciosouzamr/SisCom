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
    public class MercadoriaController: IDisposable
    {
        static MercadoriaService _mercadoriaService;
        private readonly MeuDbContext MeuDbContext;

        public MercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _mercadoriaService = new MercadoriaService(new MercadoriaRepository(meuDbContext), notifier);
        }

        public async Task<MercadoriaViewModel> Adicionar(MercadoriaViewModel MercadoriaViewModel)
        {
            var Mercadoria = Declaracoes.mapper.Map<Mercadoria>(MercadoriaViewModel);

            await _mercadoriaService.Adicionar(Mercadoria);

            return Declaracoes.mapper.Map<MercadoriaViewModel>(Mercadoria);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _mercadoriaService.Excluir(Id);

            return true;
        }

        public async Task<MercadoriaViewModel> Atualizar(Guid id, MercadoriaViewModel MercadoriaViewModel)
        {
            await _mercadoriaService.Atualizar(Declaracoes.mapper.Map<Mercadoria>(MercadoriaViewModel));

            return MercadoriaViewModel;
        }

        public async Task<IEnumerable<MercadoriaViewModel>> ObterTodos()
        {
            var obterTodos = await _mercadoriaService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<MercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var Mercadoria = await _mercadoriaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaViewModel>>(Mercadoria);
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
