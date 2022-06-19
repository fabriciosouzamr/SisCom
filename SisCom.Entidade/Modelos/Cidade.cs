using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class Cidade : Entity
    {
        public string CodigoIBGE { get; set; }
        public string Nome { get; set; }
        public Guid EstadoId { get; set; }

        /* EF Relation */
        public Estado Estado { get; set; }
    }
}
