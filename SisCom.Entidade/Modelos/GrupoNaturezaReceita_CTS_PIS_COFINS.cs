using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class GrupoNaturezaReceita_CTS_PIS_COFINS : Entity
    {
        public SubGrupoNaturezaReceita_CTS_PIS_COFINS SubGrupoNaturezaReceita_CTS_PIS_COFINS { get; set; }
        public TabelaCST_PIS_COFINS TabelaCST_PIS_COFINSRelacionado01 { get; set; }
        public TabelaCST_PIS_COFINS TabelaCST_PIS_COFINSRelacionado02 { get; set; }

        public string Codigo { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid? SubGrupoNaturezaReceita_CTS_PIS_COFINSId { get; set; }
        public Guid TabelaCST_PIS_COFINSRelacionado01Id { get; set; }
        public Guid TabelaCST_PIS_COFINSRelacionado02Id { get; set; }
    }
}
