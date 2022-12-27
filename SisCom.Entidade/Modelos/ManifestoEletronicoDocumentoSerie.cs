using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class ManifestoEletronicoDocumentoSerie : Entity
    {
        public Empresa Empresa { get; set; }
        public string Serie { get; set; }
        public String UltimoNumeroManifestoEletronicoDocumento { get; set; }
        public ManifestoEletronicoDocumento UltimoManifestoEletronicoDocumento { get; set; }

        /* EF Relation */
        public Guid? UltimoManifestoEletronicoDocumentoId { get; set; }
        public Guid EmpresaId { get; set; }
    }
}