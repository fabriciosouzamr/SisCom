using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NotaFiscalSaidaSerie : Entity
    {
        public string Serie { get; set; }
        public string UltimaNotaFiscal { get; set; }
        public NotaFiscalSaida UltimaNotaFiscalSaida { get; set; }

        /* EF Relation */
        public Guid? UltimaNotaFiscalSaidaId { get; set; }
    }
}