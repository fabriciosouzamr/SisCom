using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class MDFeAdicionarNotasItemViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string NotaFiscal { get; set; }
        public string? CodigoChaveAcesso { get; set; }
    }
}