using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class VeiculoPlaca : Entity
    {
        public string NumeroPlaca { get; set; }
        public Cidade Cidade { get; set; }
        public string CodigoRenavan { get; set; }

        /* EF Relation */
        public Guid? CidadeId { get; set; }
    }
}
