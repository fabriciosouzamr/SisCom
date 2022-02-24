using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using static API_Consultas.AcoesAPI;

public class API_Consultas
{
	public class AcoesAPI
	{
		public class Resposta
		{
			public bool Sucesso { get; set; }
			public object data { get; set; }
			public HttpStatusCode CodigoHttp { get; set; } = HttpStatusCode.OK;
			public string MotivoErro { get; set; }
		}

		public class AtividadePrincipal
		{
			public string text { get; set; }
			public string code { get; set; }
		}

		public class AtividadesSecundaria
		{
			public string text { get; set; }
			public string code { get; set; }
		}

		public class Qsa
		{
			public string qual { get; set; }
			public string nome { get; set; }
			public string qual_rep_legal { get; set; }
			public string nome_rep_legal { get; set; }
		}
		public class Billing
		{
			public bool free { get; set; }
			public bool database { get; set; }
		}

		public class Extra
		{
		}

		public class CNPJRetorno
		{
			public List<AtividadePrincipal> atividade_principal { get; set; }
			public string data_situacao { get; set; }
			public string nome { get; set; }
			public string uf { get; set; }
			public string telefone { get; set; }
			public string email { get; set; }
			public List<AtividadesSecundaria> atividades_secundarias { get; set; }
			public List<Qsa> qsa { get; set; }
			public string situacao { get; set; }
			public string bairro { get; set; }
			public string logradouro { get; set; }
			public string numero { get; set; }
			public string cep { get; set; }
			public string municipio { get; set; }
			public string abertura { get; set; }
			public string natureza_juridica { get; set; }
			public string fantasia { get; set; }
			public string cnpj { get; set; }
			public DateTime ultima_atualizacao { get; set; }
			public string status { get; set; }
			public string tipo { get; set; }
			public string complemento { get; set; }
			public string efr { get; set; }
			public string motivo_situacao { get; set; }
			public string situacao_especial { get; set; }
			public string data_situacao_especial { get; set; }
			public string capital_social { get; set; }
			public Extra extra { get; set; }
			public Billing billing { get; set; }
		}

		public class CNPJDados
		{
			public class CNAEsSecundarios
			{
				public string Codigo { get; set; }
				public string Descricao { get; set; }
			}

			public class Ender
			{
				public string Logradouro { get; set; }
				public string Numero { get; set; }
				public string CEP { get; set; }
				public string Bairro { get; set; }
				public string Municipio { get; set; }
				public string UF { get; set; }
				public string Complemento { get; set; }
				public string Email { get; set; }
				public string Telefone { get; set; }
			}

			public class QuadroSociosAdm
			{
				public string Nome { get; set; }
				public string Qualificacao { get; set; }
				public string NomeRepLegal { get; set; }
				public string QualRepLegal { get; set; }
			}

			public string CNPJ { get; set; }
			public string NomeFantasia { get; set; }
			public string RazaoSocial { get; set; }
			public string Situacao { get; set; }
			public string MotivoSituacao { get; set; }
			public DateTime? DataAbertura { get; set; }
			public DateTime? DataSituacao { get; set; }
			public string SituacaoEspecial { get; set; }
			public DateTime? DataSituacaoEspecial { get; set; }
			public string CNAEPrincipal { get; set; }
			public string CNAEPrincipalDescricao { get; set; }
			public string NaturezaJuridica { get; set; }
			public List<CNAEsSecundarios> CNAESecundarios { get; set; }
			public Ender Endereco { get; set; }
			public List<QuadroSociosAdm> QuadroSociosAdms { get; set; }
			public double CapitalSocial { get; set; }
			public DateTime? UltimaAtualizacaoWebService { get; set; }
			public bool database { get; set; }
		}

		public static class ReceitaWS
		{
			public static CNPJRetorno ConsultarCNPJ(string CNPJ)
            {
				CNPJRetorno CNPJRetorno = null;
				var _uri = "https://www.receitaws.com.br/v1/cnpj/" + CNPJ;

				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpResponseMessage respToken = client.GetAsync(_uri).Result;
					string conteudo = respToken.Content.ReadAsStringAsync().Result;

					Console.WriteLine(conteudo + "\n");

					if (respToken.StatusCode == HttpStatusCode.OK)
					{
						CNPJRetorno = JsonConvert.DeserializeObject<CNPJRetorno>(conteudo);
					}

					client.Dispose();
				}

				return CNPJRetorno;
			}
		}

		public class CEPRetorno
		{
			public string xLgr { get; set; }
			public string xCpl { get; set; }
			public string xBairro { get; set; }
			public string cMun { get; set; }
			public string xMun { get; set; }
			public string cep { get; set; }
			public string uf { get; set; }
		}

		public static CEPRetorno ConsultaCEP(string cep)
		{
			var _uri = "https://softcomconsultacep.azurewebsites.net/api/" + cep;
			string conteudo = "";
			CEPRetorno CEPRetorno = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("x-functions-key", "m15sD2naGyWrvp68JGD4oEOLoz91FPPznxu5wBzL11w3V6oroCjdAQ==");
				HttpResponseMessage respToken = client.GetAsync(_uri).Result;
				conteudo = respToken.Content.ReadAsStringAsync().Result;

				Console.WriteLine(conteudo + "\n");

				if (respToken.StatusCode == HttpStatusCode.OK)
				{
					CEPRetorno = JsonConvert.DeserializeObject<CEPRetorno>(conteudo);
				}

				client.Dispose();
			}

			return CEPRetorno;
		}

	}
}
