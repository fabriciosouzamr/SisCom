using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class SubGrupoMercadoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid GrupoId { get; set; }
    }

    public class SubGrupoMercadoriaComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
