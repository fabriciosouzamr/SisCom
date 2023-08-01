using DFe.Classes.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class FiscalEstadoIcmsViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Estado EstadoOrigem { get; set; }
        public Estado EstadoDestino { get; set; }
        public decimal Icms { get; set; }

        /* EF Relation */
        public Guid EstadoOrigemId { get; set; }
        public Guid EstadoDestinoId { get; set; }
    }
}