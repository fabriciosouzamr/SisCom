using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class EmpresaService : BaseService<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository,
                              INotifier notificador) : base(notificador, EmpresaRepository)
        {
            _empresaRepository = EmpresaRepository;
        }

        public virtual async Task Adicionar(Empresa Empresa)
        {
            try
            {
                var empresa = await _empresaRepository.Search(f => f.CNPJ == Empresa.CNPJ || 
                                                                   f.RazaoSocial == Empresa.RazaoSocial ||
                                                                   f.Unidade == Empresa.Unidade);

                if (empresa.Count() != 0)
                {
                    Notify("Já existe uma empresa com este CNPJ, Razão Social ou Unidade informado.");
                    return;
                }

                await _empresaRepository.Insert(Empresa);

                Notify("Empresa incluída.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public virtual async Task Atualizar(Empresa Empresa)
        {
            try
            {
                if (!RunValidation(new EmpresaValidation(), Empresa)) return;

                var exists = _empresaRepository.Exists(f => (f.CNPJ == Empresa.CNPJ || 
                                                             f.Unidade == Empresa.Unidade || 
                                                             f.RazaoSocial == Empresa.RazaoSocial) && (f.Id != Empresa.Id));

                if (exists)
                {
                    Notify("Já existe uma empresa com este CNPJ, Razão Social ou Unidade informado.");
                    return;
                }

                await _empresaRepository.Update(Empresa);

                Notify("Empresa atualizada.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Excluir(Guid id)
        {
            await _empresaRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }

        public override void Dispose()
        {
            _empresaRepository?.Dispose();
        }

        public Task<IPagedList<Empresa>> GetPagedList(FilteredPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Empresa>> Search(Expression<Func<Empresa, bool>> predicate, Expression<Func<Empresa, object>> order = null)
        {
            var empresa = await _empresaRepository.Search(predicate, order);

            return empresa;
        }
    }
}
