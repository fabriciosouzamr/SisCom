using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
    {
        public class TipoServicoFiscalViewModel
        {
            [Key]
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Codigo { get; set; }
        }
    }
