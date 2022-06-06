using Funcoes._Entity;
using Funcoes._Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NaturezaOperacao : Entity
    {
        public string Nome { get; set; }
        public TabelaCFOP TabelaCFOP { get; set; }
        public EntradaSaida EntradaSaida { get; set; }
        public Decimal PercentualICMS { get; set; }
        public Boolean Devolucao { get; set; }

        /* EF Relation */
        public Guid? TabelaCFOPId { get; set; }
    }
}
