using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaMotivoDesoneracaoICMSViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public TabelaCST_CSOSN TabelaCST_CSOSN { get; set; }

        /* EF Relation */
        public Guid TabelaCST_CSOSNId { get; set; }
    }
}
