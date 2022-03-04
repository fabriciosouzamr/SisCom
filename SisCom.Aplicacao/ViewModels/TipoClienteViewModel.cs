using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TipoClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
    public class TipoClienteComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}