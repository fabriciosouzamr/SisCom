using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    class SubGrupoNaturezaReceita_CTS_PIS_COFINSViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }

    }
}
