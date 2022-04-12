using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaNCM : Entity
    {
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