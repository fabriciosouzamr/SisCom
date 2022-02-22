using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaNaturezaReceita_CTS_PIS_COFINS : Entity
    {
        public GrupoNaturezaReceita_CTS_PIS_COFINS GrupoNaturezaReceita_CTS_PIS_COFINS { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid GrupoNaturezaReceita_CTS_PIS_COFINSId { get; set; }
    }
}