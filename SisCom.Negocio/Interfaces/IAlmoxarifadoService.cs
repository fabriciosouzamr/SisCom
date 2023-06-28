using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Interfaces
{
    public interface IAlmoxarifadoService : IDisposable
    {
        Task Adicionar(Almoxarifado almoxarifado);
        Task Atualizar(Almoxarifado almoxarifado);
        Task Excluir(Guid id);
        Task<Almoxarifado> GetById(Guid id);
    }
}
