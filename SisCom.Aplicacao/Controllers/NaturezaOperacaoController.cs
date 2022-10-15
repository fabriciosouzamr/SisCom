using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class NaturezaOperacaoController : IDisposable
    {
        static NaturezaOperacaoService _NaturezaOperacaoService;
        private readonly MeuDbContext MeuDbContext;

        public NaturezaOperacaoController(MeuDbContext MeuDbContext, INotifier notifier)
        {
            this.MeuDbContext = MeuDbContext;

            _NaturezaOperacaoService = new NaturezaOperacaoService(new NaturezaOperacaoRepository(this.MeuDbContext), notifier);
        }

        public async Task<IEnumerable<NaturezaOperacaoViewModel>> ObterTodos()
        {
            var obterTodos = await _NaturezaOperacaoService.GetAll(o => o.Id, i => i.TabelaCFOP);
            return Declaracoes.mapper.Map<IEnumerable<NaturezaOperacaoViewModel>>(obterTodos);
        }

        public async Task<IEnumerable<ComboNaturezaOperacaoViewModel>> Combo(Expression<Func<NaturezaOperacao, object>> order = null)
        {
            var ret = await _NaturezaOperacaoService.GetAll(order, i => i.TabelaCFOP);

            IList<ComboNaturezaOperacaoViewModel> combo = new List<ComboNaturezaOperacaoViewModel>();

            foreach (var item in ret)
            {
                ComboNaturezaOperacaoViewModel comboitem = new ComboNaturezaOperacaoViewModel();

                comboitem.Id = item.Id;
                comboitem.TabelaCFOPId = item.TabelaCFOPId;
                if (item.TabelaCFOP == null)
                {
                    comboitem.Nome = item.Nome;
                }
                else
                {
                    comboitem.Nome = item.TabelaCFOP.Codigo + " - " + item.Nome;
                }

                combo.Add(comboitem);
            }

            return combo;
        }
        public async Task<IEnumerable<NaturezaOperacaoViewModel>> PesquisarId(Guid Id)
        {
            var nota = await _NaturezaOperacaoService.Search(p => p.Id == Id);
            return Declaracoes.mapper.Map<IEnumerable<NaturezaOperacaoViewModel>>(nota);
        }
        public async Task<NaturezaOperacaoViewModel> Adicionar(NaturezaOperacaoViewModel naturezaOperacaoViewModel)
        {
            var naturezaOperacao = Declaracoes.mapper.Map<NaturezaOperacao>(naturezaOperacaoViewModel);

            await _NaturezaOperacaoService.Adicionar(naturezaOperacao);

            return Declaracoes.mapper.Map<NaturezaOperacaoViewModel>(naturezaOperacao);
        }
        public async Task<NaturezaOperacaoViewModel> Atualizar(Guid id, NaturezaOperacaoViewModel naturezaOperacaoViewModel)
        {
            await _NaturezaOperacaoService.Atualizar(Declaracoes.mapper.Map<NaturezaOperacao>(naturezaOperacaoViewModel));

            return naturezaOperacaoViewModel;
        }

        public void Dispose()
        {
            MeuDbContext.Dispose();
        }
    }
}
