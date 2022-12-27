using Funcoes._Entity;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class ManifestoEletronicoDocumentoNota : Entity
    {
        public ManifestoEletronicoDocumento ManifestoEletronicoDocumento { get; set; }
        public NotaFiscalEntrada NotaFiscalEntrada { get; set; }
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public MDFe_TipoManifestoEletronicoDocumentoNotas TipoManifestoEletronicoDocumentoNotas { get; set; }
        public string? NumeroNotaFiscal { get; set; }
        public string? ChaveAcesso { get; set; }
        public Cidade? CidadeDescarga { get; set; }
        public decimal ValorNota { get; set; }
        public decimal PesoNota { get; set; }

        /* EF Relation */
        public Guid ManifestoEletronicoDocumentoId { get; set; }
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? NotaFiscalEntradaId { get; set; }
    }
}
