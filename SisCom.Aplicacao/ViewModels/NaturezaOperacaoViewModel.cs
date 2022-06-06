using Funcoes._Enum;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.ViewModels
{
    public class NaturezaOperacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TabelaCFOP TabelaCFOP { get; set; }
        public EntradaSaida EntradaSaida { get; set; }
        public Decimal PercentualICMS { get; set; }
        public Boolean Devolucao { get; set; }

        /* EF Relation */
        public Guid? TabelaCFOPId { get; set; }
    }
}
