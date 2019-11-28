using System;

// You need to install the package Pomelo.EntityFrameworkCore.MySql
// 
// dotnet add package Pomelo.EntityFrameworkCore.MySql

using MySql.Data.MySqlClient;

namespace mysqlexample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // If you want to take configurations from 
            // appsettings.json configs file

            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var Iconfig =  builder.Build();

            // default is the name of the connection specified on the appsettings.json file
            var connectionString = Iconfig.GetConnectionString("Default");
            
             */


            var connectionString = "Server=<myserver>;Database=<mydb>;User ID=root;Password=";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from mytable", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["my_table_column_string"].ToString());
                    }
                }
            }
        }
    }
}
