// See https://aka.ms/new-console-template for more information

using System;
using Todo_console_app.Data;
using Microsoft.Data.Sqlite;
//for hashing passswords

namespace TestConsoleApp
{
    internal class Program
    {
        //used when empty strings not allowed
        static string ReadRequiredInput(string prompt)
        {
            string? input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(input));

            return input; // Safe: guaranteed non-null
        }

        //login
        static bool Login()
        {
            //ask for user information
            string username = ReadRequiredInput("Please enter your username");
            string password = ReadRequiredInput("Please enter your password");
            //salt and hash password

            //check if in systems
            if (Data.validateUser(username, password))
            {
                Console.WriteLine("Login successful");
                Console.WriteLine($"Welcome, {username}");
            }
            else //user not in system
            {
                Console.WriteLine("Invalid Credentials");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            return true;
        }

        public static string GenerateSalt()
        {
            string value = "3";//RandomNumberGenerator.GetBytes(16);
            return value;
        }

        static void CreateAcc()
        {
            //get user details
            string username = ReadRequiredInput("Please enter a username");
            string password = ReadRequiredInput("Please enter a password");

            //input into sql database
            Data.createUser(username, password);
            Console.WriteLine("User {0} has been initialised. Press any key to continue", username);
        }

        static void Main(string[] args)
        {
            //create variables
            System.Console.WriteLine("Starting...");

            //create instance
            Data.Initialise(); //double check, how to test
            Console.WriteLine("Database initialised.");

            Data.Seed();

            bool accessGRANT = false;

            ConsoleKeyInfo menu; //selects the menu
            Console.Clear();
            //auth loop to check if user in system
            while (!accessGRANT)
            {
                Console.WriteLine("");
                Console.WriteLine("Please select an option");
                Console.WriteLine("[1] : Login \n[2] : Create Account \n[0] : Exit");
                menu = Console.ReadKey();

                switch(menu.Key)
                {
                    case ConsoleKey.D1: //Login
                    case ConsoleKey.NumPad1:
                        if(Login()) //if login successful
                        {
                            accessGRANT = true;
                        }
                        break;

                    case ConsoleKey.D2: //Create Account
                    case ConsoleKey.NumPad2:
                        CreateAcc();
                        break;

                    case ConsoleKey.D0: //Exit the progrram
                    case ConsoleKey.NumPad0: 
                        return;

                    default:
                        Console.WriteLine("Invalid selection.\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }                
            }

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
