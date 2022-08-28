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
        public Estado EstadoOrigem { get; set; }
        public Estado EstadoDestino { get; set; }
        public decimal PercentualICMS_Interno { get; set; }
        public decimal PercentualICMS_Destino { get; set; }
        public Guid? EstadoOrigemId { get; set; }
        public Guid? EstadoDestinoId { get; set; }
    }
}
