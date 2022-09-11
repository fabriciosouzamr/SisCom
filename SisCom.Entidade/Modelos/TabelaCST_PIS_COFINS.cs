using Funcoes._Entity;

namespace SisCom.Entidade.Modelos
{
    public class TabelaCST_PIS_COFINS : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool DestacarPIS_COFINS { get; set; }
        public bool UsaNaEntrada { get; set; }
        public bool UsaNaSaida { get; set; }
        public bool Percentual { get; set; }
    }
}