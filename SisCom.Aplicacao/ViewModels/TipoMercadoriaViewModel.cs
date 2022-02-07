using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TipoMercadoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}