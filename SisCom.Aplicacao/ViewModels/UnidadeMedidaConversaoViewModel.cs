using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class UnidadeMedidaConversaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public UnidadeMedida UnidadeMedidaA { get; set; }
        public UnidadeMedida UnidadeMedidaB { get; set; }
        public decimal Conversor { get; set; }

        /* EF Relation */
        public Guid UnidadeMedidaAId { get; set; }
        public Guid UnidadeMedidaBId { get; set; }
    }
}