using Funcoes._Entity;
using System;

namespace SisCom.Entidade.Modelos
{
    public class NotaFiscalSaidaObservacao : Entity
    {
        public NotaFiscalSaida NotaFiscalSaida { get; set; }
        public Observacao Observacao { get; set; }
        public string Descricao { get; set; }

        /* EF Relation */
        public Guid? NotaFiscalSaidaId { get; set; }
        public Guid? ObservacaoId { get; set; }
    }
}
