using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_console_app.Data
{
    internal class Data
    {

        private const string ConnectionString = "Data Source=app.db";

        //initialise SQL Data
        public static void Initialise()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            // initialise schema.sql

            connection.Close();
        }

        //function to recall information (to test and expand ability of function
        public static void GetUserCount()
        {
            /*using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "";

            var result = command.ExecuteScalar();
            return result;*/
        }

        //check the username exists
        public static bool validateUser(string username, string password)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            //check if the username exists within the username table
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT EXISTS(
                SELECT 1 FROM Users
                WHERE Username = @Username
                AND   Passwrd_Hash = @PasswordHash
                );
            ";

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@PasswordHash", password);

            var result = command.ExecuteScalar();
            int exists = Convert.ToInt32(result);
            return exists == 1;
        }

        public static void createUser(string username, string password)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            //create command for generating a new user
            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO Users (Username, Passwrd_Hash)
            VALUES (@Username, @PasswordHash)
            ";

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@PasswordHash", password);

            var result = command.ExecuteScalar();
        }
    }
}
