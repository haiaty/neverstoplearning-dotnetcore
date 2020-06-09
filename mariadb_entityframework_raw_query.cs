/*

//to install EF Core, you install the package for the EF Core database provider(s) you want to target. 
//https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli

install the package for MariaDB:

dotnet add package Pomelo.EntityFrameworkCore.MySql

*/

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MyNamespace
{
    class Program
    {
        //Define a context class
        public class MyContext : DbContext
        {
            public DbSet<Log> Logs { get; set; }
 
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // we are using MariaDb but the metnod name is UseMysql
                optionsBuilder.UseMySql(
                    @"Server=localhost;Database=<mydb>;User ID=root;Password=<mypass>");
            }
        }

        //... and entity classes that make up the model.
        
        // in this model you can model the columns of the table
        // that you are quering for
        public class Log
        {
            public int Id { get; set; }
            
            public string column_table_name { get; set; }
        }


        static void Main(string[] args)
        {

            using (var db = new MyContext())
            {
                Console.WriteLine("Querying for a Log");
                var blog = db.Logs
                    .FromSqlRaw("SELECT * FROM schema.table_name")
                    .First();


                Console.WriteLine(blog.column_table_name);

            }
        }
    }
}
