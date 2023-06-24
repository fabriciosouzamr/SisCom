using Funcoes._Entity;
using Funcoes._Enum;
using SisCom.Entidade.Enum;
using System;

namespace SisCom.Entidade.Modelos
{
    public class EstoqueLancamento : Entity
    {
        public EstoqueLancamento()
        {
            Data = DateTime.Now;
        }

        public Estoque Estoque { get; set; }
        public TipoLancamentoEstoque TipoLancamentoEstoque { get; set; }
        public EntradaSaida EntradaSaida { get; set; }
        public DateTime Data { get; set; }
        public Double Quantidade { get; set; }
        public String Comentario { get; set; }

        /* EF Relation */
        public Guid EstoqueId { get; set; }
    }
}
