using Funcoes._Entity;

namespace SisCom.Entidade.Modelos
{
    public class ContaFinanceira : Entity
    {
        public Banco Banco { get; set; }
        public string Nome { get; set; }
    }
}
