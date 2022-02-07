﻿using Funcoes.Classes;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaMotivoDesoneracaoICMS : Entity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public TabelaCST_CSOSN TabelaCST_CSOSN { get; set; }

        /* EF Relation */
        public Guid TabelaCST_CSOSNId { get; set; }
    }
}
