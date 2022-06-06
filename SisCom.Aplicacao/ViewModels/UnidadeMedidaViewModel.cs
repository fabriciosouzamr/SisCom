using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class UnidadeMedidaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UnidadeMedidaAId { get; set; }
        public Guid UnidadeMedidaBId { get; set; }
        public decimal Conversor { get; set; }
    }
}