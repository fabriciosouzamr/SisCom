using Funcoes._Entity;
using Funcoes._Enum;

namespace SisCom.Entidade.Modelos
{
    public class Transportadora : Entity
    {
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CNPJ_CPF { get; set; }
        public string? InscricaoEstadual { get; set; }
        public Endereco? Endereco { get; set; }
        public string? PlacaVeiculo { get; set; }
        public string? PlacaCarreta01 { get; set; }
        public string? PlacaCarreta02 { get; set; }
        public string? NomeContato { get; set; }
        public string? Telefone { get; set; }
    }
}