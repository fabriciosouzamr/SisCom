using Funcoes.Classes;
using SisCom.Entidade.Enum;

namespace SisCom.Entidade.Modelos
{
    public class TabelaModalidadeDeterminacaoBCICMS : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public TipoModalidadeDeterminacaoBCICMS TipoModalidadeDeterminacaoBCICMS { get; set; }
    }
}