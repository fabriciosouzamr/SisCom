using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaCFOPViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public GrupoCFOP GrupoCFOP { get; set; }
        /* EF Relation */
        public Guid GrupoCFOPId { get; set; }
    }
}
