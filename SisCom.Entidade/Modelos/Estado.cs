using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class Estado : Entity
    {
        public string CodigoIBGE { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public Pais Pais { get; set; }

        /* EF Relation */
        public Guid PaisId { get; set; }
    }
}