using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool AcessoFinanceiro { get; set; }
        public bool AcessoFiscal { get; set; }
        public bool Administrador { get; set; }
        public bool Desativado { get; set; }
    }
    public class FuncionarioComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}