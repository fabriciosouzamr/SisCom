using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CNPJ_CPF { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Nome { get; set; }
        public string NomePopular { get; set; }
        public string End_CEP { get; set; }
        public string End_Logradouro { get; set; }
        public string End_Numero { get; set; }
        public string End_Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public string Telefone { get; set; }
        public string FAX { get; set; }
        public string Contato { get; set; }
        public string EMail { get; set; }
        public string Site { get; set; }
        public string Representante { get; set; }
        public string Observacoes { get; set; }

        /* EF Relation */
        public Cidade End_CidadeId { get; set; }
        public TipoPessoa TipoPessoaId { get; set; }
    }

    public class PessoaComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
