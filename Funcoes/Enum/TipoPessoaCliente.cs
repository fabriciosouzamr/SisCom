using System.ComponentModel;

namespace Funcoes._Enum
{
    public enum TipoPessoaCliente
    {
        [Description("Física")]
        Fisica = 1,
        [Description("Juridica")]
        Juridica = 2,
        [Description("Especial")]
        Especial = 3
    }
}
