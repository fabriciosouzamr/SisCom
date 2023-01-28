using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class ManifestoEletronicoDocumentoPercurso : Entity
    {
        public ManifestoEletronicoDocumento ManifestoEletronicoDocumento { get; set; }
        public Estado Estado { get; set; }
        public int Ordem { get; set; }

        /* EF Relation */
        public Guid ManifestoEletronicoDocumentoId { get; set; }
        public Guid EstadoId { get; set; }
    }
}
