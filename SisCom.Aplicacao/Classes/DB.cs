using Microsoft.Data.SqlClient;
using SisCom.Aplicacao.Configuration;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace SisCom.Aplicacao.Classes
{
    public static class DB
    {
        public static DataTable Executar(string query)
        {
            DataTable ret = new DataTable();
            AppSettings appSettings;

            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration", "appsettings.json");
            using (StreamReader file = File.OpenText(appSettingsPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                appSettings = (AppSettings)serializer.Deserialize(file, typeof(AppSettings));
            }

            using (SqlConnection conn = new SqlConnection(appSettings.ConnectionStrings.DefaultConnection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, conn);
                adapter.Fill(ret);
            }

            return ret;
        }
    }
}
