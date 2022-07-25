using DanfeSharp.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Classes
{
    public static class Fiscal
    {
        public static void GerarDanfe(string sXML, bool imprimirCancelado, bool abrirArquivo)
        {
            string sXML_Local = Arquivo.DiretorioMontarCaminhoArquivo(Declaracoes.Aplicacao_CaminhoDiretorioTemporaria, "Danfe.xml");
            string sDanfe = Arquivo.ArquivoTemporario("Danfe.pdf");

            if (File.Exists(sXML_Local)) { File.Delete(sXML_Local); }
            if (File.Exists(sDanfe)) { File.Delete(sDanfe); }

            FileStream fs = new FileStream(sXML_Local, FileMode.Create);

            StreamWriter writer = new StreamWriter(fs);
            writer.Write(sXML);
            writer.Close();

            DanfeViewModel oModelo = DanfeViewModel.CreateFromXmlFile(sXML_Local);
            DanfeSharp.Danfe oDanfe;

            
            oDanfe = new DanfeSharp.Danfe(oModelo);

            //If FNC_NVL(sEMPRESA_DS_PATH_IMAGEM, "") <> "" Then
            //    Dim stream As New System.IO.FileStream(sEMPRESA_DS_PATH_IMAGEM, System.IO.FileMode.Open)
            //    'oDanfe.AdicionarLogoImagem(sEMPRESA_DS_PATH_IMAGEM)
            //    oDanfe.AdicionarLogoImagem(stream)
            //End If

            oDanfe.Rodape = "Gerado pelo DixMed";
            oDanfe.ImprimirCancelado = imprimirCancelado;
            oDanfe.Gerar();
            oDanfe.Salvar(sDanfe);

            if(abrirArquivo) { System.Diagnostics.Process.Start("explorer.exe", sDanfe); }
        }
    }
}
