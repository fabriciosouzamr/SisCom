using Funcoes.Classes;
using System;

namespace SisCom.Entidade.Modelos
{
    public class MercadoriaFornecedor : Entity
    {
        public Pessoa Fornecedor { get; set; }
        public Mercadoria Mercadoria { get; set; }
        public string CodigoFonecedor { get; set; }

        public double QuantidadePorCaixa { get; set; }

        /* EF Relation */
        public Guid FornecedorId { get; set; }
        public Guid MercadoriaId { get; set; }
    }
}