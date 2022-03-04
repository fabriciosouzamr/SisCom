using Funcoes._Enum;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class PessoaViewModel: BaseModelView
    {
        public string CNPJ_CPF { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public TipoPessoaCliente TipoPessoa { get; set; }
        public DateTime? DataNascimento { get; set; }
        public TipoContribuinte? TipoContribuinte { get; set; }
        public string? RG { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public Endereco? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? FAX { get; set; }
        public string? NomeContato { get; set; }
        public string? EMail { get; set; }
        public string? Site { get; set; }
        public string? Representante { get; set; }
        public string? Observacoes { get; set; }
        public Funcionario? Vendedor { get; set; }
        public TipoCliente? TipoCliente { get; set; }
        public RegimeTributario? RegimeTributario { get; set; }
        public bool SelecionarEtiqueta { get; set; }
        public bool Desativado { get; set; }
        public bool UsarFoto { get; set; }
        public byte[]? Imagem { get; set; }
        public DateTime DatCadastro { get; set; }
        public bool Fornecedor { get; set; }

        /* EF Relation */
        public Nullable<Guid> VendedorId { get; set; }
        public Nullable<Guid> TipoClienteId { get; set; }
    }

    public class PessoaComboNomeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }

    public class PessoaComboRazaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
    }

    public class PessoaComboCodigoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
    }

    public class PessoaComboCPFCNPJViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string CNPJ_CPF { get; set; }
    }

    public class PessoaComboTelefoneViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Telefone { get; set; }
    }
}
