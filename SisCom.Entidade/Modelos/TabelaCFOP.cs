using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaCFOP : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public GrupoCFOP GrupoCFOP { get; set; }
        /* EF Relation */
        public Guid GrupoCFOPId { get; set; }
    }
}
