using Funcoes.Classes;
using System;

namespace SisCom.Entidade.Modelos
{
    public class TabelaCST_CSOSN : Entity
    {
        public string Codigo { get; set;  }
        public string Descricao { get; set; }
        public bool DestacarICMS { get; set; }
        public bool DestacarICMSST { get; set; }
        public bool PossuiDesoneracaoICMS { get; set; }
        public int CRT { get; set; }
        public string ST { get; set; }
        public string CSTEquivalente { get; set; }
        public bool PossuiDiferimentoICMS { get; set; }
        public bool PossuiReducaoICMS { get; set; }
        public bool DestacarICMSSTEfetivo { get; set; }
    }
}

