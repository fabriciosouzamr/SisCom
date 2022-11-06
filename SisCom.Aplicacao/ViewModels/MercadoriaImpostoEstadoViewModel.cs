using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class MercadoriaImpostoEstadoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public decimal PercentualICMS { get; set; }
        public Guid? MercadoriaId { get; set; }
        public Guid? EstadoOrigemId { get; set; }
        public Guid? EstadoDestinoId { get; set; }
    }
}
