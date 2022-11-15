using Funcoes._Enum;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class EmpresaViewModel: BaseModelView
    {
        public string CNPJ { get; set; }
        public string Unidade { get; set; }

        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoEstadual_SubTributaria { get; set; }
        public string? CodigoCNAEPrincipal { get; set; }
        public Endereco? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? EMail { get; set; }
        public RegimeTributario? RegimeTributario { get; set; }
        public double CreditoSimplesNacional { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public AmbienteSistemas? NFE_Ambiente { get; set; }
        public string? NFE_VersaoEmissor { get; set; }
        public NFE_Layout? NFE_Layout { get; set; }
        public string? NFE_Serie { get; set; }
        public string? PathLogomarca { get; set; }
        public string? PathDocumentoFiscal { get; set; }
        public byte[]? ImagemLogomarca { get; set; }
        public Sped_TipoGeracaoInventario? Sped_TipoGeracaoInventario { get; set; }
        public string? MDFe_Serie { get; set; }
        public AmbienteSistemas? MDFe_Ambiente { get; set; }
        public TipoEmissor? MDFe_TipoEmirssor { get; set; }
        public bool NuvemFiscal_Usar { get; set; }
        public AmbienteSistemas? NuvemFiscal_AmbienteWebService { get; set; }
        public string? NuvemFiscal_Certificado { get; set; }
        public string? NuvemFiscal_SerialNumber { get; set; }
        public string NSU { get; set; }
        public string? Controle { get; set; }
    }

    public class EmpresaComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Unidade { get; set; }
        public string RazaoSocial { get; set; }
    }

    public class EmpresaNuvemFiscalComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Unidade { get; set; }
        public string CNPJ { get; set; }
        public bool NuvemFiscal_Usar { get; set; }
        public AmbienteSistemas? NuvemFiscal_AmbienteWebService { get; set; }
        public string? NuvemFiscal_Certificado { get; set; }
        public string? NuvemFiscal_SerialNumber { get; set; }

        public Estado Estado { get; set; }
        public string NSU { get; set; }
    }
}
