using Funcoes._Entity;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class GrupoCFOP : Entity
    {
        public string Nome { get; set; }

        public TipoOperacaoCFOP TipoOperacaoCFOP { get; set; }

        /* EF Relation */

        public Guid TipoOperacaoCFOPId { get; set; }

    }
}
