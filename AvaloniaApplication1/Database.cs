using System.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace AvaloniaApplication1;

public class Database
{
    MySqlConnection connection = new MySqlConnection("server=cfif31.ru;user ID=ISPr24-38_GilazovaAR;password=ISPr24-38_GilazovaAR;database=ISPr24-38_GilazovaAR_DoctorMag;CharSet=utf8;Timeout=3600");
    public static Database Instance = new Database();

    public Database()
    {
        connection.Open();
    }

    public DataTable SqlZapros(string sql)
    {
        MySqlCommand command = new MySqlCommand();
        using (var reader = command.ExecuteReader())
        {
            DataTable table = new DataTable();
            table.Load(reader);
            return table;
        }
    }

    public void NonQuerryZapros(string sql)
    {
        MySqlCommand command = new MySqlCommand(sql,connection);
        command.ExecuteNonQuery();
    }
}