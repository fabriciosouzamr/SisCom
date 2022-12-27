
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class ManifestoEletronicoDocumentoSerieViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Empresa Empresa { get; set; }
        public string Serie { get; set; }
        public String UltimoNumeroManifestoEletronicoDocumento { get; set; }
        public ManifestoEletronicoDocumento UltimoManifestoEletronicoDocumento { get; set; }

        /* EF Relation */
        public Guid? UltimoManifestoEletronicoDocumentoId { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
