using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IPessoaService : IDisposable
    {
        Task Adicionar(Pessoa Pessoa);
        Task Atualizar(Pessoa Pessoa);
        Task Remover(Guid id);
        Task<List<Pessoa>> GetAll();

        Task<List<Pessoa>> Combo();
        Task<List<Pessoa>> ComboFornecedor();
        Task<Pessoa> GetById(Guid id);

        Task<IPagedList<Pessoa>> GetPagedList(FilteredPagedListParameters parameters);
    }
}
