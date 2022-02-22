using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class SubGrupoMercadoriaService : BaseService<SubGrupoMercadoria>, ISubGrupoMercadoriaService
    {
        private readonly ISubGrupoMercadoriaRepository _SubGrupoRepository;

        public SubGrupoMercadoriaService(ISubGrupoMercadoriaRepository SubGrupoRepository,
                             INotifier notificador) : base(notificador, SubGrupoRepository)
        {
            _SubGrupoRepository = SubGrupoRepository;
        }

        public async Task Adicionar(SubGrupoMercadoria SubGrupo)
        {
            if (!RunValidation(new SubGrupoValidation(), SubGrupo)) return;

            if (_SubGrupoRepository.Search(f => f.Nome == SubGrupo.Nome).Result.Any())
            {
                Notify("Já existe um plano de conta com este nome informado.");
                return;
            }

            await _SubGrupoRepository.Insert(SubGrupo);
        }

        public async Task Atualizar(SubGrupoMercadoria SubGrupo)
        {
            if (!RunValidation(new SubGrupoValidation(), SubGrupo)) return;

            if (_SubGrupoRepository.Search(f => f.Nome == SubGrupo.Nome && f.Id != SubGrupo.Id).Result.Any())
            {
                Notify("Já existe um plano de conta com este nome infomado.");
                return;
            }

            await _SubGrupoRepository.Update(SubGrupo);
        }

        public async Task Remover(Guid id)
        {
            await _SubGrupoRepository.Delete(id);
        }

        public Task<IPagedList<SubGrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _SubGrupoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _SubGrupoRepository?.Dispose();
        }

        public Task<List<SubGrupoMercadoria>> Combo()
        {
            throw new NotImplementedException();
        }
    }
}
