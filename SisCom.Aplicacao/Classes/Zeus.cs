using NFe.Utils.NFe;

namespace SisCom.Aplicacao.Classes
{
    public static class Zeus
    {
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
    }
}
