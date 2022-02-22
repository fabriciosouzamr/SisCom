using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
    public class EstadoComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
    public class EstadoCodigoComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
    }
}