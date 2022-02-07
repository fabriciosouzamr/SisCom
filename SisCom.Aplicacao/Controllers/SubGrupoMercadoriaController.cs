using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Repository;
using SisCom.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Controllers
{
    public class SubGrupoMercadoriaController
    {
        static SubGrupoMercadoriaService _SubGrupoMercadoriaService;

        static SubGrupoMercadoriaController()
        {
            _SubGrupoMercadoriaService = new SubGrupoMercadoriaService(new SubGrupoRepository(Declaracoes.dbContext), null);
        }

        public SubGrupoMercadoriaViewModel Adicionar(SubGrupoMercadoriaViewModel subGrupoMercadoriaViewModel)
        {
            _SubGrupoMercadoriaService.Adicionar(Declaracoes.mapper.Map<SubGrupoMercadoria>(subGrupoMercadoriaViewModel));

            return subGrupoMercadoriaViewModel;
        }

        public SubGrupoMercadoriaViewModel Atualizar(Guid id, SubGrupoMercadoriaViewModel subGrupoMercadoriaViewModel)
        {
            _SubGrupoMercadoriaService.Atualizar(Declaracoes.mapper.Map<SubGrupoMercadoria>(subGrupoMercadoriaViewModel));

            return subGrupoMercadoriaViewModel;
        }

        public IEnumerable<SubGrupoMercadoriaViewModel> ObterTodos()
        {
            return Declaracoes.mapper.Map<IEnumerable<SubGrupoMercadoriaViewModel>>(_SubGrupoMercadoriaService.GetAll());
        }

        public async Task<IEnumerable<SubGrupoMercadoriaComboViewModel>> Combo()
        {
            var combo = await _SubGrupoMercadoriaService.Combo();
            return Declaracoes.mapper.Map<IEnumerable<SubGrupoMercadoriaComboViewModel>>(combo);
        }
    }
}
