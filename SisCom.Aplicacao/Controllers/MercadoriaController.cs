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
    public class MercadoriaController
    {
        static MercadoriaService _MercadoriaService;
        private readonly MeuDbContext MeuDbContext;

        public MercadoriaController(MeuDbContext meuDbContext, INotifier notifier)
        {
            this.MeuDbContext = meuDbContext;

            _MercadoriaService = new MercadoriaService(new MercadoriaRepository(meuDbContext), notifier);
        }

        public async Task<MercadoriaViewModel> Adicionar(MercadoriaViewModel MercadoriaViewModel)
        {
            var Mercadoria = Declaracoes.mapper.Map<Mercadoria>(MercadoriaViewModel);

            await _MercadoriaService.Adicionar(Mercadoria);

            return Declaracoes.mapper.Map<MercadoriaViewModel>(Mercadoria);
        }

        public async Task<bool> Excluir(Guid Id)
        {
            await _MercadoriaService.Excluir(Id);

            return true;
        }

        public async Task<MercadoriaViewModel> Atualizar(Guid id, MercadoriaViewModel MercadoriaViewModel)
        {
            await _MercadoriaService.Atualizar(Declaracoes.mapper.Map<Mercadoria>(MercadoriaViewModel));

            return MercadoriaViewModel;
        }

        public IEnumerable<MercadoriaViewModel> ObterTodos()
        {
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaViewModel>>(_MercadoriaService.GetAll());
        }

        public async Task<IEnumerable<MercadoriaViewModel>> PesquisarId(Guid Id)
        {
            var Mercadoria = await _MercadoriaService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<MercadoriaViewModel>>(Mercadoria);
        }
    }
}
