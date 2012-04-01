using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Simple.Data;
using System.Data.SQLite;

namespace SimpleDataAndSqlLite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create DB using System.Data.SQLite
            if (!File.Exists("test.db"))
            {
                File.Delete("test.db");
            }

            var con = new SQLiteConnection("Data Source=test.db");
            con.Open();

            var createTableCommand = new SQLiteCommand("CREATE TABLE IF NOT EXISTS fool (field1 CHAR(100))", con);
            createTableCommand.ExecuteNonQuery();

            // Create some sample data using System.Data.SQLite
            for (int i = 0; i < 10; i++)
            {
                var insertDataCommand =
                       new SQLiteCommand(
                           "INSERT INTO fool (field1) VALUES ('Value " + i + "')",
                           con);
                insertDataCommand.ExecuteNonQuery();
            }

            con.Close();

            // Add to the DB with Simple.Data.Sqlite
            var db = Database.OpenFile("test.db");
            db.fool.Insert(field1: "Yet Another Value 1");
            db.fool.Insert(field1: "Yet Another Value 2");
            db.fool.Insert(field1: "Yet Another Value 3");

            // Query Database with Simple.Data.Sqlite
            var fool = db.fool.All();
            foreach (var foo in fool)
            {
                Console.WriteLine("{0}", foo.field1);
            }

            Console.ReadLine();
        }
    }
}
