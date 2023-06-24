using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class EstoqueUnidadeMedidaConversaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MercadoriaId { get; set; }
        public Guid UnidadeMedidaId { get; set; }
        public double FatorConversao { get; set; }
    }
}
