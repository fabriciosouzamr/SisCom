using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaCEST : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public TabelaNCM TabelaNCM { get; set; }

        /* EF Relation */
        public Guid TabelaNCMId { get; set; }
    }
}