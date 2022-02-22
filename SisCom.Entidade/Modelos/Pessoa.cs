using Funcoes._Entity;
using Funcoes._Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class Pessoa : Entity
    {
        public string CNPJ_CPF { get; set; }
        public string Nome { get; set; }
        public string NomePopular { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string End_CEP { get; set; }
        public string End_Logradouro { get; set; }
        public string End_Numero { get; set; }
        public string End_Bairro { get; set; }
        public string End_PontoReferencia { get; set; }

        public Cidade End_Cidade { get; set; }
        public string Telefone { get; set; }
        public string FAX { get; set; }
        public string NomeContato { get; set; }
        public string EMail { get; set; }
        public string Site { get; set; }
        public string Representante { get; set; }
        public string Observacoes { get; set; }

        public bool Fornecedor { get; set; }

        public bool Fabricante { get; set; }

        /* EF Relation */
        public Nullable<Guid> End_CidadeId { get; set; }
    }
}
