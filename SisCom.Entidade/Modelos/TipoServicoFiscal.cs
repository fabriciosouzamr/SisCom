using Funcoes.Classes;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TipoServicoFiscal : Entity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public TabelaCNAE TabelaCNAE { get; set; }

        /* EF Relation */
        public Guid TabelaCNAEId { get; set; }
    }
}
