using AutoMapper;
using Funcoes.Interfaces;
using Funcoes.Notifications;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SisCom.Aplicacao.Classes
{
    public static class Declaracoes
    {
        public static MeuDbContext dbContext;
        public static MapperConfiguration configuration;
        public static Mapper mapper;

        public const string Aplicacao_Nome = "Sistema Comercial";
        public const string Aplicacao_CaminhoFoto = "\\fotos\\";
        public static string Aplicacao_CaminhoDiretorioTemporaria = "\\temp\\";

        public const int CampoNome_Caracteres = 100;

        public static string sistema_UsuarioLogado = "Administrador";
        public static string sistema_Loja = "Loja Teste";

        public static object ComboBox_Carregando = 1;

        public static eTipoCalculo tipoCalculo = eTipoCalculo.Padrao;
        public static eCalculoPreco calculoPreco = eCalculoPreco.Compra;

        public static string Externos_SisCom_Aplicacao_FW = "";
        public static string Externos_Path_Schemas = "";
        public static string Externos_Path_NuvemFiscal = "";

        public static Guid dados_Empresa_Id;
        public static Guid dados_Empresa_EstadoId;

        public enum eNavegar
        {
            Primeiro,
            Anterior,
            Atual,
            Proximo,
            Ultimo
        }

        public enum eTipoCalculo
        {
            Padrao = 1,
            TVA = 2
        }

        public enum eCalculoPreco
        {
            Compra = 1,
            Venda = 2
        }

        public enum TipoManifestar
        {
            [Description("Confirmacao da Operacao")]
            TeMdConfirmacaoDaOperacao = 210200,
            [Description("Ciencia da Operacao")]
            TeMdCienciaDaOperacao = 210210,
            [Description("Desconhecimento da Operacao")]
            TeMdDesconhecimentoDaOperacao = 210220,
            [Description("Operacao nao Realizada")]
            TeMdOperacaoNaoRealizada = 210240
        }
    }

    public class NotaFiscalManifestar
    {
        public string NFe { set; get; }
        public string Serie { set; get; }
        public DateTime Emissao { set; get; }
        public double Valor { set; get; }
        public string ChaveAcesso { get; set; }
        public string CNPJ { get; set; }
    }
    public class NotaFiscalMercadoriaDetalhamentoImposto
    {
        public decimal Preco { set; get; }
        public decimal ValorBaseCalculo { set; get; }
        public decimal AliquotaICMS { set; get; }
        public decimal ValorICMS { set; get; }
        public decimal AliquotaReducao { set; get; }
        public decimal ValorBaseSubstituicaoTributaria { set; get; }
        public decimal ValorSubstituicaoTributaria { set; get; }
        public decimal ValorAdicional { set; get; }
        public decimal AliquotaAdicional { set; get; }
        public Guid? CSTIPI { set; get; }
        public decimal ValorBaseIPI { set; get; }
        public decimal AliquotaIPI { set; get; }
        public decimal ValorIPI { set; get; }
        public Guid? CSTPIS { set; get; }
        public decimal AliquotaPIS { set; get; }
        public Guid? CSTCOFINS { set; get; }
        public decimal AliquotaCOFINS { set; get; }
        public decimal BaseCalculoFCP { set; get; }
        public decimal AliquotaFCP { set; get; }
        public decimal ValorFCP { set; get; }
        public string NumeroPedidoCompra { set; get; }
        public string ItemPedidoCompra { set; get; }
    }

    public static class Texto
    {
        public static string Mensagem_Fabricante_Remover = "Deseja remover o fabricante [Param01]?";
        public static string Mensagem_TipoCliente_Remover = "Deseja remover o tipo de cliente [Param01]?";
        public static string Mensagem_Grupo_NaoSelecionado = "Não foi selecionado nenhum grupo!";
        public static string Mensagem_Grupo_Remover = "Deseja remover o grupo [Param01]?";
    }

    public class Notifier : INotifier
    {
        public List<Notification> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public void Handle(Notification notification)
        {
            CaixaMensagem.Informacao(notification.Key);
        }

        public void Handle(string notification)
        {
            CaixaMensagem.Informacao(notification);
        }

        public bool HasNotification()
        {
            throw new NotImplementedException();
        }
    }
}
