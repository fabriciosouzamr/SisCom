using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class ManifestoEletronicoDocumentoPercursoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public ManifestoEletronicoDocumentoViewModel ManifestoEletronicoDocumento { get; set; }
        public EstadoViewModel Estado { get; set; }
        public int Ordem { get; set; }

        /* EF Relation */
        public Guid ManifestoEletronicoDocumentoId { get; set; }
        public Guid EstadoId { get; set; }
    }
}
