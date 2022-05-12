using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Funcoes.Classes
{
    public static class NuvemFiscal
	{
		public class CertificateBrowserDialog
		{
			private X509Certificate2 _SelectedCertificate;

			public X509Certificate2 SelectedCertificate
			{
				get
				{
					return _SelectedCertificate;
				}
				private set
				{
					_SelectedCertificate = value;
				}
			}

			public DialogResult ShowDialog(bool ValidOnly = true)
			{
				X509Certificate2 x509Certificate = new X509Certificate2();
				X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
				x509Store.Open(OpenFlags.OpenExistingOnly);
				X509Certificate2Collection certificates = x509Store.Certificates;
				X509Certificate2Collection x509Certificate2Collection = certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, ValidOnly);
				X509Certificate2Collection certificates2 = certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, ValidOnly);
				X509Certificate2Collection x509Certificate2Collection2 = X509Certificate2UI.SelectFromCollection(certificates2, "Certificado(s) Digital(is) disponível(is)", Conversions.ToString(Operators.ConcatenateObject("Selecione o certificado digital para uso no aplicativo.", Interaction.IIf(ValidOnly, "\r\n*Apenas os certificados válidos serão listados.", ""))), X509SelectionFlag.SingleSelection);
				if (x509Certificate2Collection2.Count == 0)
				{
					return DialogResult.Abort;
				}
				x509Certificate = (SelectedCertificate = x509Certificate2Collection2[0]);
				return DialogResult.OK;
			}

			public void ViewSelectedCertificate(X509Certificate2 YouCertificate)
			{
				if (YouCertificate == null)
				{
					Interaction.MsgBox("Nenhum certificado foi selecionado.", MsgBoxStyle.Exclamation, "Advertência");
				}
				else
				{
					X509Certificate2UI.DisplayCertificate(YouCertificate);
				}
			}

			public X509Certificate2 getCerticateByString(string strFind, bool ValidOnly = true)
			{
				if (Operators.CompareString(strFind, "", TextCompare: false) == 0)
				{
					return null;
				}
				X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
				x509Store.Open(OpenFlags.OpenExistingOnly);
				X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
				bool flag = default(bool);
				if (strFind.Contains("CN=") & strFind.Contains("OU="))
				{
					flag = true;
				}
				x509Certificate2Collection = ((!flag) ? x509Store.Certificates.Find(X509FindType.FindBySubjectName, strFind, ValidOnly) : x509Store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, strFind, ValidOnly));
				if (x509Certificate2Collection.Count > 0)
				{
					return x509Certificate2Collection[0];
				}
				return null;
			}

			public bool CertificateIsA3(X509Certificate2 YouCertificate)
			{
				return ((RSACryptoServiceProvider)YouCertificate.PrivateKey).CspKeyContainerInfo.Removable;
			}
		}
	public static string getVencimentoCertificado(string NomeCertificado, bool ValidOnly = false)
{
	try
	{
		CertificateBrowserDialog certificateBrowserDialog = new CertificateBrowserDialog();
		X509Certificate2 certicateByString = certificateBrowserDialog.getCerticateByString(NomeCertificado, ValidOnly);
		if (Information.IsNothing(certicateByString))
		{
			return "";
		}
		return certicateByString.GetExpirationDateString();
	}
	catch (Exception ex)
	{
		ProjectData.SetProjectError(ex);
		Exception ex2 = ex;
		string result = "";
		ProjectData.ClearProjectError();
		return result;
	}
}

		public static string SelecionarCertificado()
		{
			try
			{
				CertificateBrowserDialog certificateBrowserDialog = new CertificateBrowserDialog();
				DialogResult dialogResult = certificateBrowserDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					return certificateBrowserDialog.SelectedCertificate.Subject;
				}
				return "";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw;
			}
			finally
			{
				CertificateBrowserDialog certificateBrowserDialog = null;
			}
		}
	}
}
