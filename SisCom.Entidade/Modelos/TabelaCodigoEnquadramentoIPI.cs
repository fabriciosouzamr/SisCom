using Funcoes.Classes;
using SisCom.Entidade.Enum;

namespace SisCom.Entidade.Modelos
{
    public class TabelaCodigoEnquadramentoIPI : Entity
    {
        public GrupoTabelaCodigoEnquadramentoIPI GrupoTabelaCodigoEnquadramentoIPI { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}