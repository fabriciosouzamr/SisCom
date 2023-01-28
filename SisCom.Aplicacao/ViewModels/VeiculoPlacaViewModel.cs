using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class VeiculoPlacaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public String NumeroPlaca { get; set; }
        public Estado Estado { get; set; }
        public string? Renavam { get; set; }
        public double TaraKG { get; set; }
        public double CapacidadeKG { get; set; }
        public double CapacidadeM3 { get; set; }
        public MDFe_TipoRodado? TipoRodado { get; set; }
        public MDFe_TipoCarroceria? TipoCarroceria { get; set; }
        public string? Terceiros_NomeProprietario { get; set; }
        public string? Terceiros_CPFCNPJProprietario { get; set; }
        public string? Terceiros_IEProprietario { get; set; }
        public string? Terceiros_RNTRCProprietario { get; set; }
        public MDFe_TipoProprietario? Terceiros_TipoProprietario { get; set; }
        public Estado? Terceiros_EstadoProprietario { get; set; }

        /* EF Relation */
        public Guid? EstadoId { get; set; }
        public Guid? Terceiros_EstadoProprietarioId { get; set; }
    }
}
