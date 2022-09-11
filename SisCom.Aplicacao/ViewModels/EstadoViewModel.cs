using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string CodigoIBGE { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public Guid PaisId { get; set; }
    }
}