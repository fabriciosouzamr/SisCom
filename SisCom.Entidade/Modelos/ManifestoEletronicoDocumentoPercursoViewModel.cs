using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Entidade.Modelos
{
    public class ManifestoEletronicoDocumentoPercursoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public ManifestoEletronicoDocumento ManifestoEletronicoDocumento { get; set; }
        public Estado Estado { get; set; }

        /* EF Relation */
        public Guid ManifestoEletronicoDocumentoId { get; set; }
        public Guid EstadoId { get; set; }
    }
}
