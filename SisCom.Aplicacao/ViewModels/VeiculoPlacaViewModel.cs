using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class VeiculoPlacaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string NumeroPlaca { get; set; }
        public Cidade Cidade { get; set; }
        public string CodigoRenavan { get; set; }

        /* EF Relation */
        public Guid? CidadeId { get; set; }

    }
}
