using Funcoes._Entity;
using SisCom.Entidade.Enum;
using System;
using System.Collections.Generic;

namespace SisCom.Entidade.Modelos
{
    public class ManifestoEletronicoDocumento : Entity
    {
        public Empresa Empresa { get; set; }
        public DateTime DataHoraEmissao { get; set; }
        public string Numero { get; set; }
        public ManifestoEletronicoDocumentoSerie ManifestoEletronicoDocumentoSerie { get; set; }
        public string Carga {get; set;}
        public MDFe_TipoEmissao TipoEmissao { get; set; }
        public Estado? EstadoCarregamento { get; set; }
        public Cidade? CidadeCarregamento { get; set; }
        public Estado? EstadoDescarga { get; set; }
        public MDFe_TipoTransportador? TipoTransportador { get; set; }
        public string? RNTRCEmitente { get; set; }

        public VeiculoPlaca? DadoVeiculo_Placa { get; set; }
        public Estado? DadoVeiculo_Estado { get; set; }
        public string? DadoVeiculo_Renavam { get; set; }
        public double DadoVeiculo_TaraKG { get; set; }
        public double DadoVeiculo_CapacidadeKG { get; set; }
        public double DadoVeiculo_CapacidadeM3 { get; set; }
        public MDFe_TipoRodado? DadoVeiculo_TipoRodado { get; set; }
        public MDFe_TipoCarroceria? DadoVeiculo_TipoCarroceria { get; set; }
        public string? DadoVeiculoVeiculoTerceiros_NomeProprietario { get; set; }
        public string? DadoVeiculoVeiculoTerceiros_CPFCNPJProprietario { get; set; }
        public string? DadoVeiculoVeiculoTerceiros_IEProprietario { get; set; }
        public string? DadoVeiculoVeiculoTerceiros_RNTRCProprietario { get; set; }
        public MDFe_TipoProprietario? DadoVeiculoVeiculoTerceiros_TipoProprietario { get; set; }
        public Estado? DadoVeiculoVeiculoTerceiros_EstadoProprietario { get; set; }

        public int QuantidadeNFe { get; set; }
        public decimal ValorTotalCarga { get; set; }
        public decimal PesoBrutoCarga { get; set; }
        public MDFe_UidadePeso? UnidadePeso { get; set; }

        public string? Autorizacao_ChaveAutenticacao { get; set; }
        public string? Autorizacao_Protocolo { get; set; }
        public DateTime? Autorizacao_DataHoraAutorizacao { get; set; }
        public DateTime Autorizacao_DataHoraEncerramento { get; set; }

        public string? Condutor_CPF { get; set; }
        public string? Condutor_Nome { get; set; }

        public string? InformacoesAdicionaisInteresseFisco { get; set; }
        public string? InformacoesComplementaresInteresseContribuinte { get; set; }

        public MDFe_Status Status { get; set; }

        /* EF Relation */
        public Guid? EmpresaId { get; set; }
        public Guid ManifestoEletronicoDocumentoSerieId { get; set; }
        public Guid? EstadoCarregamentoId { get; set; }
        public Guid? CidadeCarregamentoId { get; set; }
        public Guid? EstadoDescargaId { get; set; }
        public Guid? DadoVeiculo_PlacaId { get; set; }
        public Guid? DadoVeiculo_EstadoId { get; set; }
        public Guid? DadoVeiculoVeiculoTerceiros_EstadoProprietarioId { get; set; }
        public virtual List<ManifestoEletronicoDocumentoNota> ManifestoEletronicoDocumentoNotas { get; set; }
        public virtual List<ManifestoEletronicoDocumentoPercurso> ManifestoEletronicoDocumentoPercursos { get; set; }
    }
}
