using Funcoes.Interfaces;
using Funcoes.PagedList;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using SisCom.Negocio.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class EmpresaService : BaseService<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository,
                              INotifier notificador) : base(notificador, EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }

        public virtual async Task Adicionar(Empresa Empresa)
        {
            try
            {
                var empresa = await _EmpresaRepository.Search(f => f.CNPJ == Empresa.CNPJ || 
                                                                   f.RazaoSocial == Empresa.RazaoSocial ||
                                                                   f.Unidade == Empresa.Unidade);

                if (empresa.Count() != 0)
                {
                    Notify("Já existe uma empresa com este CNPJ, Razão Social ou Unidade informado.");
                    return;
                }

                await _EmpresaRepository.Insert(Empresa);

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

                var exists = _EmpresaRepository.Exists(f => (f.CNPJ == Empresa.CNPJ || 
                                                             f.Unidade == Empresa.Unidade || 
                                                             f.RazaoSocial == Empresa.RazaoSocial) && (f.Id != Empresa.Id));

                if (exists)
                {
                    Notify("Já existe uma empresa com este CNPJ, Razão Social ou Unidade informado.");
                    return;
                }

                await _EmpresaRepository.Update(Empresa);

                Notify("Empresa atualizada.");
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public async Task Remover(Guid id)
        {
            await _EmpresaRepository.Delete(id);
        }

        public override void Dispose()
        {
            _EmpresaRepository?.Dispose();
        }

        public Task<IPagedList<Empresa>> GetPagedList(FilteredPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
