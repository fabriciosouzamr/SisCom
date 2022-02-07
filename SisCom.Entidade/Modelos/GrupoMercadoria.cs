using Funcoes.Classes;

namespace SisCom.Entidade.Modelos
{
    public class GrupoMercadoria : Entity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public bool NaoVender { get; set; }
    }
}
