using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Text;
using System.Runtime.InteropServices;

namespace Todo_console_app.Data
{
    internal class Data
    {

        private const string ConnectionString = "Data Source=app.db";

        //initialise SQL Data
        public static void Initialise()
        {
            //read in tables
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string sql = File.ReadAllText("Data/schema.sql");

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            
            connection.Close();
        }

        public static void Seed()
        {
            //read in seed data
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string sql = File.ReadAllText("Data/seed.sql");

            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            connection.Close();
        }

        //create a salt for passwords
        public static string GenerateSalt()
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);

            using var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                100_000,                 // iteration count
                HashAlgorithmName.SHA256
            );

            byte[] hash = pbkdf2.GetBytes(32); // 256-bit key
            return Convert.ToBase64String(hash);
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
            command.CommandText = @"
                SELECT Passwrd_Hash, Salt
                FROM Users
                WHERE Username = @Username;;
            ";

            command.Parameters.AddWithValue("@Username", username);

            var result = command.ExecuteReader();

            //if person is not found
            if(!result.Read())
            {
                Console.WriteLine("No person found");
                return false;
            }

            string storedHash = result.GetString(0);
            string storedSalt = result.GetString(1);

            string computedHash = HashPassword(password, storedSalt);
            Console.WriteLine(storedSalt);

            return CryptographicOperations.FixedTimeEquals( //compare the new result to the table, check if there
                    Convert.FromBase64String(computedHash),
                    Convert.FromBase64String(storedHash)
                );
        }

        public static void createUser(string username, string password)
        {
            string salt = GenerateSalt();
            password = HashPassword(password, salt);

            Console.WriteLine(password);
            Console.WriteLine(salt);
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            //create command for generating a new user
            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO Users (Username, Salt, Passwrd_Hash)
            VALUES (@Username, @Salt, @PasswordHash)
            ";

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Salt", salt);
            command.Parameters.AddWithValue("@PasswordHash", password);

            var result = command.ExecuteScalar();
        }
    }
}
