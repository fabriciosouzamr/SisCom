using Funcoes._Entity;

namespace SisCom.Entidade.Modelos
{
    public class Funcionario : Entity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool AcessoFinanceiro { get; set; }
        public bool AcessoFiscal { get; set; }
        public bool Administrador { get; set; }
        public bool Desativado { get; set; }
    }
}
