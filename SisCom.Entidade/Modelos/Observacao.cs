using Funcoes._Entity;
using SisCom.Entidade.Enum;

namespace SisCom.Entidade.Modelos
{
    public class Observacao : Entity
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public TipoObservacao TipoObservacao { get; set; }
        public bool Ativo { get; set; }
    }
}