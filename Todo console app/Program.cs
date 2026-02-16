// See https://aka.ms/new-console-template for more information

using System;
using Todo_console_app.Data;
using Microsoft.Data.Sqlite;
//for hashing passswords
using System.Text;
using System.Security.Cryptography;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create variables
            System.Console.WriteLine("Starting...");

            //create instance
            Data.Initialise(); //double check, how to test
            Console.Write("Database initialised.");

            bool accessGRANT = false;
            string username;
            string password;
            //populate / read data
            //check if the user has an account with the system

            while (!accessGRANT)
            {
                //ask for user information
                Console.WriteLine("Please enter your username");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                password = Console.ReadLine();
                //salt and hash password

                //check if in systems
                if(Data.validateUser(username, password))
                {
                    Console.WriteLine("Login successful");
                    Console.WriteLine("Welcome, {username}", username);
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                    Console.WriteLine("Press any key to continue");
                }
                    //if password not match, loop back
            }
            //if password match, proceed

            //ask user abt expenses or todolist

            //get data

            //todo LIST

            //function to output

            //allow modification


            //EXPENSES



            //interact with data
        }
    }
}
