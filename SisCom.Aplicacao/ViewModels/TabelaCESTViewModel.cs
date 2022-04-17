using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaCESTViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public TabelaNCM TabelaNCM { get; set; }

        /* EF Relation */
        public Guid? TabelaNCMId { get; set; }
    }
}
