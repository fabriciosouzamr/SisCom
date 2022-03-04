using SisCom.Entidade.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaModalidadeDeterminacaoBCICMSViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public TipoModalidadeDeterminacaoBCICMS TipoModalidadeDeterminacaoBCICMS { get; set; }
    }
}
