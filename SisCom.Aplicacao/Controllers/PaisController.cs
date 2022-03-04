using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class PaisController
    {
        static PaisService _PaisService;
        private readonly MeuDbContext MeuDbContext;

        public PaisController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _PaisService = new PaisService(new PaisRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<PaisViewModel>> ObterTodos()
        {
            var obterTodos = await _PaisService.GetAll();
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<PaisViewModel>> Combo()
        {
            var combo = await _PaisService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(combo);
        }

        public async Task<IEnumerable<PaisViewModel>> ComboId(Guid Id)
        {
            var combo = await _PaisService.ComboSearch(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<PaisViewModel>>(combo);
        }
    }
}
