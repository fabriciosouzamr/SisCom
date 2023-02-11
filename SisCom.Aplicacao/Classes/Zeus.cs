using Funcoes._Enum;
using NFe.Utils.NFe;
using NFe.Utils.Tributacao.Estadual;
using NFe.Utils.Tributacao.Federal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SisCom.Aplicacao.Classes
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(RetEnvEvento));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (RetEnvEvento)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "infEvento")]
    public class InfEvento
    {
        [XmlElement(ElementName = "tpAmb")]
        public int TpAmb { get; set; }

        [XmlElement(ElementName = "verAplic")]
        public string VerAplic { get; set; }

        [XmlElement(ElementName = "cOrgao")]
        public int COrgao { get; set; }

        [XmlElement(ElementName = "cStat")]
        public int CStat { get; set; }

        [XmlElement(ElementName = "xMotivo")]
        public string XMotivo { get; set; }

        [XmlElement(ElementName = "chNFe")]
        public double ChNFe { get; set; }

        [XmlElement(ElementName = "tpEvento")]
        public int TpEvento { get; set; }

        [XmlElement(ElementName = "xEvento")]
        public string XEvento { get; set; }

        [XmlElement(ElementName = "nSeqEvento")]
        public int NSeqEvento { get; set; }

        [XmlElement(ElementName = "dhRegEvento")]
        public DateTime DhRegEvento { get; set; }
    }

    [XmlRoot(ElementName = "retEvento")]
    public class RetEvento
    {

        [XmlElement(ElementName = "infEvento")]
        public InfEvento InfEvento { get; set; }

        [XmlAttribute(AttributeName = "versao")]
        public double Versao { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "retEnvEvento")]
    public class RetEnvEvento
    {
        [XmlElement(ElementName = "idLote")]
        public int IdLote { get; set; }
        [XmlElement(ElementName = "tpAmb")]
        public int TpAmb { get; set; }
        [XmlElement(ElementName = "verAplic")]
        public string VerAplic { get; set; }
        [XmlElement(ElementName = "cOrgao")]
        public int COrgao { get; set; }
        [XmlElement(ElementName = "cStat")]
        public int CStat { get; set; }
        [XmlElement(ElementName = "xMotivo")]
        public string XMotivo { get; set; }
        [XmlElement(ElementName = "retEvento")]
        public RetEvento RetEvento { get; set; }
    }

    public class retDistDFeInt
    {
        public int tpAmb { get; set; }
        public string verAplic { get; set; }
        public int cStat { get; set; }
        public string xMotivo { get; set; }
        public string dhResp { get; set; }
        public int ultNSU { get; set; }
        public int maxNSU { get; set; }
    }

    [XmlRoot(ElementName = "Protocolo")]
    public class Protocolo
    {
        [XmlElement(ElementName = "cStat")]
        public int CStat { get; set; }

        [XmlElement(ElementName = "xMotivo")]
        public string XMotivo { get; set; }

        [XmlElement(ElementName = "nProtocolo")]
        public string NProtocolo { get; set; }
    }

    [XmlRoot(ElementName = "infRec")]
    public class infRec
    {
        [XmlElement(ElementName = "tMed")]
        public int tMed { get; set; }

        [XmlElement(ElementName = "nRec")]
        public string NRec { get; set; }
    }

    [XmlRoot(ElementName = "retEnviNFe")]
    public class retEnviNFe
    {
        [XmlElement(ElementName = "tpAmb")]
        public int TpAmb { get; set; }

        [XmlElement(ElementName = "verAplic")]
        public string VerAplic { get; set; }
        [XmlElement(ElementName = "cStat")]
        public int CStat { get; set; }

        [XmlElement(ElementName = "xMotivo")]
        public string XMotivo { get; set; }
        [XmlElement(ElementName = "cUF")]
        public int cUF { get; set; }

        [XmlElement(ElementName = "dhRegEvento")]
        public DateTime dhRegEvento { get; set; }

        [XmlElement(ElementName = "infRec")]
        public RetEvento infRec { get; set; }
        [XmlElement(ElementName = "nRec")]
        public int nRec { get; set; }
        [XmlElement(ElementName = "tMed")]
        public int tMed { get; set; }

        [XmlElement(ElementName = "Protocolo")]
        public Protocolo Protocolo { get; set; }
    }

    public static class Zeus
    {
        public static AmbienteSistemas ambienteSistemas = AmbienteSistemas.Producao;
        public static string PATH_SCHEMAS;

        public static NFe.Classes.nfeProc CarregarNFE_XML(ref string arquivoXml)
        {
            arquivoXml = Arquivo.CarregarArquivoXML();

            NFe.Classes.nfeProc _nfeProc = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(arquivoXml))
                    try
                    {
                        _nfeProc = new NFe.Classes.nfeProc().CarregarDeArquivoXml(arquivoXml);
                    }
                    catch (System.Exception)
                    {
                        _nfeProc = new NFe.Classes.nfeProc();
                        _nfeProc.NFe = new NFe.Classes.NFe().CarregarDeArquivoXml(arquivoXml);
                    }
            }
            catch (System.Exception)
            {
            }

            return _nfeProc;
        }

        public static RetEnvEvento Manifestar(string chaveacesso, string nFeTipoEvento)
        {
            List<string> retorno;

            retorno = Processo.Executar(Declaracoes.externos_SisCom_Aplicacao_FW, "manifestar " + Declaracoes.dados_Empresa_CodigoEstado + " " + 
                                                                                                  chaveacesso + " " + 
                                                                                                  Declaracoes.dados_Empresa_CNPJ + " " + 
                                                                                                  nFeTipoEvento + " " + 
                                                                                                  Declaracoes.dados_Empresa_SerialNumber);

            if ((retorno != null) && (retorno.Count > 0))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RetEnvEvento));

                using (StringReader reader = new StringReader(XML_RetirarVersao(retorno[0].ToString())))
                {
                    var retEnvEvento = (RetEnvEvento)serializer.Deserialize(reader);
                    return retEnvEvento;
                }
            }
            else
            {
                return null;
            }
        }

        public static RetEnvEvento CartaCorrecao(string chaveacesso, string arquivo, int idLote)
        {
            List<string> retorno;

            retorno = Processo.Executar(Declaracoes.externos_SisCom_Aplicacao_FW, "cartacorrecao " + Declaracoes.dados_Empresa_CodigoEstado + " " +
                                                                                                     chaveacesso + " " +
                                                                                                     Declaracoes.dados_Empresa_CNPJ + " " +
                                                                                                     "'" + arquivo + "' " +
                                                                                                     Declaracoes.dados_Empresa_SerialNumber + " " +
                                                                                                     idLote.ToString());

            if ((retorno != null) && (retorno.Count > 0))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RetEnvEvento));

                using (StringReader reader = new StringReader(XML_RetirarVersao(retorno[0].ToString())))
                {
                    var retEnvEvento = (RetEnvEvento)serializer.Deserialize(reader);
                    return retEnvEvento;
                }
            }
            else
            {
                return null;
            }
        }

        public static RetEnvEvento Cancelamento(string chaveacesso, string arquivo, string protocolo, int idLote)
        {
            List<string> retorno;

            retorno = Processo.Executar(Declaracoes.externos_SisCom_Aplicacao_FW, "cancelamento " + Declaracoes.dados_Empresa_CodigoEstado + " " +
                                                                                                    chaveacesso + " " +
                                                                                                    Declaracoes.dados_Empresa_CNPJ + " " +
                                                                                                    "'" + arquivo + "' " +
                                                                                                    Declaracoes.dados_Empresa_SerialNumber +  " " +
                                                                                                    protocolo + " " +
                                                                                                    idLote.ToString());

            if ((retorno != null) && (retorno.Count > 0))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RetEnvEvento));

                using (StringReader reader = new StringReader(XML_RetirarVersao(retorno[0].ToString())))
                {
                    var retEnvEvento = (RetEnvEvento)serializer.Deserialize(reader);
                    return retEnvEvento;
                }
            }
            else
            {
                return null;
            }
        }

        public static retEnviNFe Protocolar(string xml)
        {
            List<string> retorno;

            retorno = Processo.Executar(Declaracoes.externos_SisCom_Aplicacao_FW, "protocolar " + Declaracoes.dados_Empresa_CodigoEstado + " " + 
                                                                                                  "'" + xml + "' " +
                                                                                                  Declaracoes.dados_Empresa_SerialNumber);

            if ((retorno != null) && (retorno.Count > 0))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(retEnviNFe));

                using (StringReader reader = new StringReader(XML_RetirarVersao(retorno[0].ToString())))
                {
                    var retEnviNFe = (retEnviNFe)serializer.Deserialize(reader);
                    return retEnviNFe;
                }
            }
            else
            {
                return null;
            }
        }

        public static retDistDFeInt NuvemFiscal(string nsu)
        {
            List<string> retorno;

            retorno = Processo.Executar(Declaracoes.externos_SisCom_Aplicacao_FW, "nuvemfiscal " + Declaracoes.dados_Empresa_CodigoEstado +  " " + 
                                                                                                   Declaracoes.dados_Empresa_CNPJ + " " + 
                                                                                                   nsu + " " + 
                                                                                                   Declaracoes.dados_Empresa_SerialNumber);

            if ((retorno != null) && (retorno.Count > 0))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(retDistDFeInt));
                                                                                  
                using (StringReader reader = new StringReader(XML_RetirarVersao(retorno[0].ToString()).Replace("<retDistDFeInt >", "<retDistDFeInt>")))
                {
                    var retEnvEvento = (retDistDFeInt)serializer.Deserialize(reader);
                    return retEnvEvento;
                }
            }
            else
            {
                return null;
            }
        }

        public static void MDFeImprimir(string chaveacesso, string status)
        {

            Processo.Executar(Declaracoes.externos_SisCom_Aplicacao_FW, "mdfeimprimir " + chaveacesso + " " +
                                                                                          status);
        }

        private static string XML_RetirarVersao(string sXML)
        {
            string ret = sXML;

            if (sXML.IndexOf("versao=") != 0)
            {
                sXML = sXML.Replace(sXML.Substring(sXML.IndexOf("versao="), sXML.IndexOf("/nfe") - sXML.IndexOf("versao=") + ("/nfe").Length + 1), "");
            }

            return sXML;
        }

        public static ICMSGeral NFe_Produto_DadosICMS(NFe.Classes.Informacoes.Detalhe.det oProduto)
        {
            ICMSGeral oICMSGeral = new ICMSGeral(oProduto.imposto.ICMS.TipoICMS);
            return oICMSGeral;
        }

        public static COFINSGeral NFE_Produto_DadosCOFINS(NFe.Classes.Informacoes.Detalhe.det oProduto)
        {
            COFINSGeral oCOFINSGeral = new COFINSGeral(oProduto.imposto.COFINS.TipoCOFINS);
            return oCOFINSGeral;
        }

        public static PISGeral NFE_Produto_DadosPIS(NFe.Classes.Informacoes.Detalhe.det oProduto)
        {
            PISGeral oPISGeral = new PISGeral(oProduto.imposto.PIS.TipoPIS);
            return oPISGeral;
        }
        public static IPIGeral NFE_Produto_DadosIPI(NFe.Classes.Informacoes.Detalhe.det oProduto)
        {
            IPIGeral oIPIGeral = new IPIGeral(oProduto.imposto.IPI.TipoIPI);
            return oIPIGeral;
        }
    }
}
