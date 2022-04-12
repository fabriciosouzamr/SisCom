using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class GrupoNaturezaReceita_CTS_PIS_COFINSViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Guid? SubGrupoNaturezaReceita_CTS_PIS_COFINSId { get; set; }
        public Guid TabelaCST_PIS_COFINSRelacionado01Id { get; set; }
        public Guid TabelaCST_PIS_COFINSRelacionado02Id { get; set; }
    }
}
