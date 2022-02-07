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
    public class GrupoMercadoriaService : BaseService<GrupoMercadoria>, IGrupoMercadoriaService
    {
        private readonly IGrupoMercadoriaRepository _GrupoProdutoRepository;

        public GrupoMercadoriaService(IGrupoMercadoriaRepository GrupoRepository,
                            INotifier notificador) : base(notificador, GrupoRepository)
        {
            _GrupoProdutoRepository = GrupoRepository;
        }

        public virtual async Task Adicionar(GrupoMercadoria GrupoProduto)
        {
            try
            {
                var grupo = await _GrupoProdutoRepository.Search(f => f.Nome == GrupoProduto.Nome);

                if (grupo.Count() != 0)
                {
                    Notify("Já existe um grupo com este nome informado.");
                    return;
                }

                await _GrupoProdutoRepository.Insert(GrupoProduto);

                Notify("Grupo incluído.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public virtual async Task Atualizar(GrupoMercadoria GrupoProduto)
        {
            try
            {
                if (!RunValidation(new GrupoValidation(), GrupoProduto)) return;

                var grupo = await _GrupoProdutoRepository.Search(f => f.Nome == GrupoProduto.Nome && f.Id != GrupoProduto.Id);

                if (grupo.Count() != 0)
                {
                    Notify("Já existe um grupo com este nome informado.");
                    return;
                }

                await _GrupoProdutoRepository.Update(GrupoProduto);

                Notify("Grupo atualizado.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Remover(Guid id)
        {
            await _GrupoProdutoRepository.Delete(id);           
        }

        public Task<IPagedList<GrupoMercadoria>> GetPagedList(FilteredPagedListParameters parameters)
        {
            return _GrupoProdutoRepository.GetPagedList(f =>
            (
                parameters.Search == null || f.Nome.Contains(parameters.Search)
            ), parameters);
        }

        public override void Dispose()
        {
            _GrupoProdutoRepository?.Dispose();
        }
    }
}
