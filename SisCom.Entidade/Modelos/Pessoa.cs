using Funcoes._Entity;
using Funcoes._Enum;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class Pessoa : Entity
    {
        public string CNPJ_CPF { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public TipoPessoaCliente TipoPessoa { get; set; }
        public  DateTime? DataNascimento { get; set; }
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
}
