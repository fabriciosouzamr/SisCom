﻿using Funcoes._Enum;
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class TransportadoraViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string CNPJ_CPF { get; set; }
        public string? InscricaoEstadual { get; set; }
        public Endereco? Endereco { get; set; }
        public string? PlacaVeiculo { get; set; }
        public string? PlacaCarreta01 { get; set; }
        public string? PlacaCarreta02 { get; set; }
        public string? NomeContato { get; set; }
        public string? Telefone { get; set; }
    }
}