using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic.CompilerServices;


namespace Funcoes._Classes
{
    public static class Hardware
    {
		public enum ENUN_INFO_PC
		{
			PC_Name,
			PC_Processador,
			PC_Memoria,
			PC_Dominio,
			PC_Usuario,
			PC_Placa_Fab,
			PC_Placa_Mod,
			SO_Name,
			SO_Bits,
			SO_Versao,
			SO_Fab,
			IP_Local,
			IP_Internet
		}

		public static string InformacaoComputador(ENUN_INFO_PC TypeInfo)
		{
			try
			{
				string path;
				switch (TypeInfo)
				{
					case ENUN_INFO_PC.IP_Local:
						return Dns.GetHostAddresses(Dns.GetHostName()).First((IPAddress a) => a.AddressFamily == AddressFamily.InterNetwork).ToString();
					case ENUN_INFO_PC.IP_Internet:
						return new WebClient().DownloadString("http://api.ipify.org");
					case ENUN_INFO_PC.PC_Processador:
						path = "Win32_Processor";
						break;
					case ENUN_INFO_PC.PC_Memoria:
						path = "Win32_PhysicalMemory";
						break;
					case ENUN_INFO_PC.PC_Dominio:
					case ENUN_INFO_PC.PC_Usuario:
					case ENUN_INFO_PC.PC_Placa_Fab:
					case ENUN_INFO_PC.PC_Placa_Mod:
						path = "Win32_ComputerSystem";
						break;
					default:
						path = "Win32_OperatingSystem";
						break;
				}
				ManagementClass managementClass = new ManagementClass(path);
				foreach (ManagementBaseObject instance in managementClass.GetInstances())
				{
					PropertyDataCollection.PropertyDataEnumerator enumerator = instance.Properties.GetEnumerator();
					while (enumerator.MoveNext())
					{
						PropertyData current2 = enumerator.Current;
						switch (TypeInfo)
						{
							case ENUN_INFO_PC.PC_Name:
								if (Operators.CompareString(current2.Name, "CSName", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.PC_Processador:
								if (Operators.CompareString(current2.Name, "Name", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.PC_Memoria:
								if (Operators.CompareString(current2.Name, "Capacity", TextCompare: false) == 0)
								{
									return Convert.ToDouble(current2.Value.ToString()) / 1073741824.0 + " GB";
								}
								break;
							case ENUN_INFO_PC.PC_Dominio:
								if (Operators.CompareString(current2.Name, "Domain", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.PC_Usuario:
								if (Operators.CompareString(current2.Name, "UserName", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.PC_Placa_Fab:
								if (Operators.CompareString(current2.Name, "Manufacturer", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.PC_Placa_Mod:
								if (Operators.CompareString(current2.Name, "Model", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.SO_Bits:
								if (Operators.CompareString(current2.Name, "OSArchitecture", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.SO_Fab:
								if (Operators.CompareString(current2.Name, "Manufacturer", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.SO_Name:
								if (Operators.CompareString(current2.Name, "Caption", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
							case ENUN_INFO_PC.SO_Versao:
								if (Operators.CompareString(current2.Name, "Version", TextCompare: false) == 0)
								{
									return current2.Value.ToString();
								}
								break;
						}
					}
				}
				return "";
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
	}
}
