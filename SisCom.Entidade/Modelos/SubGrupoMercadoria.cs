using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class SubGrupoMercadoria : Entity
    {
        public string Nome { get; set; }

        public GrupoMercadoria GrupoMercadoria { get; set; }

        /* EF Relation */
        public Guid GrupoMercadoriaId { get; set; }
    }
}
