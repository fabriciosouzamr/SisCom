using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class FuncionarioViewModel : BaseModelView
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool AcessoFinanceiro { get; set; }
        public bool AcessoFiscal { get; set; }
        public bool Administrador { get; set; }
        public bool Desativado { get; set; }
        public Empresa? EmpresaAcesso { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}