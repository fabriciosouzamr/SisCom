using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaNCMViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public GrupoNCM GrupoNCM { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid GrupoNCMId { get; set; }
    }
}
