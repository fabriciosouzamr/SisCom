using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaNCMViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double PercentualAliquotaIBPTEstadual { get; set; }
        public double PercentualAliquotaIBPTNacional { get; set; }
        public double TributosImpostados { get; set; }
        public double TributosFederais { get; set; }
        public double TributosEstaduais { get; set; }
        public double TributosMunicipais { get; set; }
        public double TotalTributos { get; set; }

    }
}
