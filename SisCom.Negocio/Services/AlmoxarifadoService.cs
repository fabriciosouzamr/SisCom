using Funcoes.Interfaces;
using SisCom.Entidade.Modelos;
using SisCom.Negocio.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Negocio.Services
{
    public class AlmoxarifadoService : BaseService<Almoxarifado>, IAlmoxarifadoService
    {
        private readonly IAlmoxarifadoRepository _almoxarifadoRepository;

        public AlmoxarifadoService(IAlmoxarifadoRepository almoxarifadoRepository,
                                   INotifier notificador) : base(notificador, almoxarifadoRepository)
        {
            _almoxarifadoRepository = almoxarifadoRepository;
        }

        public virtual async Task Adicionar(Almoxarifado almoxarifado)
        {
            try
            {
                var exists = await _almoxarifadoRepository.Search(f => f.Nome.Trim().ToString() == almoxarifado.Nome.Trim().ToString());

                if (exists.Any())
                {
                    Notify("Já existe uma almoxarifado com nome informado.");
                    return;
                }

                await _almoxarifadoRepository.Insert(almoxarifado);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }

        public virtual async Task Atualizar(Almoxarifado almoxarifado)
        {
            try
            {
                //if (!RunValidation(new almoxarifadoValidation(), almoxarifado)) return;

                var exists = _almoxarifadoRepository.Exists(f => f.Nome == almoxarifado.Nome && f.Id != almoxarifado.Id);

                if (exists)
                {
                    Notify("Já existe uma almoxarifado com nome informado.");
                    return;
                }

                await _almoxarifadoRepository.Update(almoxarifado);
            }
            catch (Exception Ex)
            {
                Notify("ERRO: " + Ex.Message + ".");
            }
        }
        public async Task Excluir(Guid id)
        {
            await _almoxarifadoRepository.Delete(id);

            Notify("Exclusão Efetuada.");
        }
        public override void Dispose()
        {
            _almoxarifadoRepository?.Dispose();
        }
    }
}
