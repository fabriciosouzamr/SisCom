using Funcoes._Enum;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;

namespace SisCom.Aplicacao.ViewModels
{
    public class EstoqueLancamentoViewModel : BaseModelView
    {
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
