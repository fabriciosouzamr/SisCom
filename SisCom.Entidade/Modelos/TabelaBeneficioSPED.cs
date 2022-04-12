using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaBeneficioSPED : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}