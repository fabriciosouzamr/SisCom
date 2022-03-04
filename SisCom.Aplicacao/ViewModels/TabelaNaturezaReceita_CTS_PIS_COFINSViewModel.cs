using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaNaturezaReceita_CTS_PIS_COFINSViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public GrupoNaturezaReceita_CTS_PIS_COFINS GrupoNaturezaReceita_CTS_PIS_COFINS { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid GrupoNaturezaReceita_CTS_PIS_COFINSId { get; set; }
    }
}
