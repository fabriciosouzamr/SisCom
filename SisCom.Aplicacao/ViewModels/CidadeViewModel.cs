using DFe.Classes.Entidades;
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CodigoIBGE { get; set; }
        public EstadoViewModel Estado { get; set; }
        public Guid EstadoId { get; set; }

        public static explicit operator CidadeViewModel(Cidade v)
        {
            throw new NotImplementedException();
        }
    }

    public class CidadeComboViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}