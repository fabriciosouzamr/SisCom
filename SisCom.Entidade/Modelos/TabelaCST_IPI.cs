using Funcoes._Entity;
using Funcoes._Enum;

namespace SisCom.Entidade.Modelos
{
    public class TabelaCST_IPI : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public EntradaSaida EntradaSaida { get; set; }

        public bool DestacarIPI { get; set; }
    }
}
