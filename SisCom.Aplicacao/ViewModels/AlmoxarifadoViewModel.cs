using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class AlmoxarifadoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}