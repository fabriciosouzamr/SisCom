using Funcoes._Entity;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NotaFiscalSaidaReferencia : Entity
    {
        public Guid NotaFiscalEntradaId { get; set; }
        public string NotaFiscal { get; set; }
        public string CodigoChaveAcesso { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
    }
}