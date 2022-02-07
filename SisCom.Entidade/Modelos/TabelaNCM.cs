using Funcoes.Classes;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaNCM : Entity
    {
        public GrupoNCM GrupoNCM { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid GrupoNCMId { get; set; }
    }
}