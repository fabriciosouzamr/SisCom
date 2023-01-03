using System.ComponentModel.DataAnnotations;
using System;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;

namespace SisCom.Aplicacao.ViewModels
{
    public class ManifestoEletronicoDocumentoNotaViewModel
    {
        [Key]
        public Guid Id { get; set; }
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
