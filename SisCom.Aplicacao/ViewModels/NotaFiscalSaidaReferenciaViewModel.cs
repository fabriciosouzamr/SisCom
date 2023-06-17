using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class NotaFiscalSaidaReferenciaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid NotaFiscalEntradaId { get; set; }
        public string NotaFiscal { get; set; }
        public string CodigoChaveAcesso { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
    }
}