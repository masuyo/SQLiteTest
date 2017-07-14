using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace SQLiteTest
{
    class DatabaseLayer
    {
        public void CreateDatabaseWPassword()
        {
            // ez tk nem is szükséges, kapcsolódásnál létrehozza, ha korábban nem létezett (lehet .db is, txt, akármi)
            SQLiteConnection.CreateFile("d:/MyDatabase.sqlite");
            SQLiteConnection _dbConnection;
            _dbConnection = new SQLiteConnection("Data Source=d:/MyDatabase.sqlite;Version=3;");
            // ezt a pw-t magasról lefossa
            _dbConnection.SetPassword("testpw");

            // _dbConnection.ChangePassword("new_password");
            // _dbConnection.ChangePassword(String.Empty); reset or remove
        }

        public SQLiteConnection ConnectionOpener()
        {
            try
            {
                SQLiteConnection _dbConnection;
                // ezt a pw-t fogja használni kódolásnál, querynél
                _dbConnection = new SQLiteConnection("Data Source=d:/MyDatabase.sqlite;Version=3;Password=testpw;");
                //_dbConnection = new SQLiteConnection("Data Source=d:/MyDatabase.sqlite;Version=3;");
                _dbConnection.Open();
                return _dbConnection;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CreateTable()
        {
            try
            {
                using (SQLiteConnection _dbConnection = ConnectionOpener())
                {
                    string sql = "create table test (blabla varchar(25))";
                    SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);

                    // returns the number of rows that have been modified - for UPDATE queries
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public bool InsertData(string randomText)
        {
            try
            {
                using (SQLiteConnection _dbConnection = ConnectionOpener())
                {
                    string sql = "insert into test (blabla) values ('" + randomText + "')"; 
                    SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);

                    // returns the number of rows that have been modified - for UPDATE queries
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public bool QueryDatabase()
        {
            try
            {
                using (SQLiteConnection _dbConnection = ConnectionOpener())
                {
                    string sql = "select * from test";
                    SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);

                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine(reader["blabla"]);
                    }
                }
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
