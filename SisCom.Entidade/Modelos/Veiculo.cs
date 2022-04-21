using Funcoes._Entity;
using SisCom.Entidade.Enum;

namespace SisCom.Entidade.Modelos
{
    public class Veiculo : Entity
    {
        public string Descricao { get; set; }
        public string Renavam { get; set; }
        public string Placa_Numero { get; set; }
        public Estado Placa_Estado { get; set; }
        public string Reboque { get; set; }
        public string Pessado_CarretaPlaca { get; set; }
        public double Pessado_TaraKG { get; set; }
        public string Pessado_ProprietarioRNTRC { get; set; }
        public double Pessado_CapacidadeKG { get; set; }
        public double Pessado_CapacidadeM3 { get; set; }
        public Veiculo_TipoRodado Pessado_TipoRodado { get; set; }
        public Veiculo_TipoCarroceria Pessado_TipoCarroceria { get; set; }
        public bool VeiculoTerceiro { get; set; }
        public string VeiculoTerceiro_Proprietario_Nome { get; set; }
        public string VeiculoTerceiro_Proprietario_CNPJ_CPF { get; set; }
        public string VeiculoTerceiro_Proprietario_IE { get; set; }
        public Estado VeiculoTerceiro_Proprietario_Estado { get; set; }
    }
}