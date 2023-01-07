using Funcoes._Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funcoes._Classes
{
    public static class Validacao
    {
        public static bool CPFCNPJ_Valido(string CPFCNPJ)
        {
            return (CNPJ_Valido(CPFCNPJ) || CPF_Valido(CPFCNPJ));
        }

        public static bool CPFCNPJ_Valido(TipoPessoa tipoPessoa, string CPFCNPJ)
        {
			bool ret = false;

			switch(tipoPessoa)
            {
				case TipoPessoa.Juridica:
					ret = CNPJ_Valido(CPFCNPJ);
					break;
				default:
					ret = CPF_Valido(CPFCNPJ);
					break;
			}

			return ret;
        }
		public static bool CNPJ_Valido(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

		public static bool CPF_Valido(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

		public static bool PIS_Valido(string pis)
		{
			int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			if (pis.Trim().Length != 11)
				return false;
			pis = pis.Trim();
			pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(pis[i].ToString()) * multiplicador[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			return pis.EndsWith(resto.ToString());
		}
		public static bool CEP_Valido(string cep)
        {
			string _cep = Texto.SomenteNumero(cep);

			return (_cep.Length == 8);
        }
		public static bool Hora_Valido(string hora)
		{
            try
            {
				if (hora.Trim().Length != 5)
					return false;

				DateTime.Parse(DateTime.Now.Date.ToString("dd/MM/yyyy") + " " + hora);

				return true;
			}
			catch (Exception)
            {
				return false;
            }
		}
    }
}
