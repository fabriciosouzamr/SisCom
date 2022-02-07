using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class CFOPViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Codigo { get; set; }

        /* EF Relation */
        public Guid GrupoCFOPId { get; set; }
    }

    public class CFOPComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}