using System;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Collections.Generic;

public class ExcelToDatabaseUpdater
{

    public void UpdateDatabase(string excelFilePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        FileInfo fileInfo = new FileInfo(excelFilePath);
        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Supondo que a planilha desejada é a primeira (índice 0)

            // Obter os valores das células desejadas
            double earings = Convert.ToDouble(worksheet.Cells["I5"].Value);
            int downloads = Convert.ToInt32(worksheet.Cells["J5"].Value);
            int costumers = Convert.ToInt32(worksheet.Cells["K5"].Value);
            int managers = Convert.ToInt32(worksheet.Cells["L5"].Value);
            int drivers = Convert.ToInt32(worksheet.Cells["M5"].Value);
            int bosses = Convert.ToInt32(worksheet.Cells["N5"].Value);
            int metaAtingida = Convert.ToInt32(worksheet.Cells["O5"].Value);
            string nome = worksheet.Cells["B1"].Value?.ToString();

            // Estabelecer a conexão com o banco de dados
            string connectionString = "Server=143.106.241.3;Database=cl201273;Uid=cl201273;Pwd=MarcosLeonardo18;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Atualizar os valores existentes no banco de dados
                string query = "UPDATE TCC_Analytics SET Earings = @Earings, Downloads = @Downloads, Costumers = @Costumers, Managers = @Managers, Drivers = @Drivers, Bosses = @Bosses, MonthlyGoal = @MetaAtingida WHERE Company = @Nome";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Earings", earings);
                command.Parameters.AddWithValue("@Downloads", downloads);
                command.Parameters.AddWithValue("@Costumers", costumers);
                command.Parameters.AddWithValue("@Managers", managers);
                command.Parameters.AddWithValue("@Drivers", drivers);
                command.Parameters.AddWithValue("@Bosses", bosses);
                command.Parameters.AddWithValue("@MetaAtingida", metaAtingida);
                command.Parameters.AddWithValue("@Nome", nome);

                command.ExecuteNonQuery();

            }
        }
    }

    public void UpdateChart(string excelFilePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        FileInfo fileInfo = new FileInfo(excelFilePath);
        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Supondo que a planilha desejada é a primeira (índice 0)

            // List para armazenar os valores
            List<double> earningValues = new List<double>();

            // Obter os valores das células desejadas
            for (int i = 4; i <= 34; i++)
            {
                string cellAddress = "B" + i;
                double value = Convert.ToDouble(worksheet.Cells[cellAddress].Value);
                earningValues.Add(value);
            }

            UpdateValues(earningValues);
        }
    }

    public void UpdateValues(List<double> earningValues)
    {
        string connectionString = "Server=143.106.241.3;Database=cl201273;Uid=cl201273;Pwd=MarcosLeonardo18;";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            for (int i = 0; i < earningValues.Count; i++)
            {
                string query = "UPDATE TCC_Grafico SET Earning" + (i + 1) + " = @Value WHERE Company = 32";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Value", earningValues[i]);

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
    }



    public Dictionary<string, object> PreencherLabels()
    {
        // Configuração da conexão com o banco de dados
        string connectionString = "Server=143.106.241.3;Database=cl201273;Uid=cl201273;Pwd=MarcosLeonardo18;";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT Earings, Downloads, Costumers, Managers, Drivers, Bosses, MonthlyGoal FROM TCC_Analytics WHERE Company = @Nome"; // Consulta SQL
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nome", "GPbuS"); // Parâmetro para a condição WHERE

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var values = new Dictionary<string, object>();

                    values["Earings"] = reader["Earings"];
                    values["Downloads"] = reader["Downloads"];
                    values["Costumers"] = reader["Costumers"];
                    values["Managers"] = reader["Managers"];
                    values["Drivers"] = reader["Drivers"];
                    values["Bosses"] = reader["Bosses"];
                    values["MonthlyGoal"] = reader["MonthlyGoal"];

                    return values;
                }
            }
        }

        return null; // Caso nenhum dado seja encontrado ou ocorra algum erro
    }

    public List<double> GetEarningsFromDatabase()
    {
        string connectionString = "Server=143.106.241.3;Database=cl201273;Uid=cl201273;Pwd=MarcosLeonardo18;";

        List<double> earnings = new List<double>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT Earning1, Earning2, Earning3, Earning4, Earning5, Earning6, Earning7, Earning8, Earning9, Earning10, Earning11, Earning12, Earning13, Earning14, Earning15, Earning16, Earning17, Earning18, Earning19, Earning20, Earning21, Earning22, Earning23, Earning24, Earning25, Earning26, Earning27, Earning28, Earning29, Earning30, Earning31 FROM TCC_Grafico WHERE Company = 32";

            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Adicione os valores de Earning1 a Earning31 na lista de earnings
                    for (int i = 0; i < 31; i++)
                    {
                        earnings.Add(reader.GetDouble(i));
                    }
                }
            }
        }

        return earnings;
    }



}
