﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TabelaSpedTipoItemViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
