using Funcoes.Classes;
using System;

namespace SisCom.Entidade.Modelos
{
    public class Cidade : Entity
    {
        public string CodigoIBGE { get; set; }
        public string Nome { get; set; }

        public Estado Estado { get; set; }

        /* EF Relation */
        public Guid EstadoId { get; set; }
    }
}
