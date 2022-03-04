using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaCST_PIS_COFINSViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool DestacarPIS_COFINS { get; set; }
        public bool UsaNaEntrada { get; set; }
        public bool UsaNaSaida { get; set; }
    }
}
