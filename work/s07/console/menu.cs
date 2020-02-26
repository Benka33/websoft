using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace jsonBank
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            var accounts = ReadAccounts();
            
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1) View accounts");
            Console.WriteLine("2) View account by number");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
         
            switch (Console.ReadLine())
            {
                case "1":
                    foreach (var account in accounts) {
                Console.WriteLine(account);
            }
                    return true;
                case "2":
                    Console.WriteLine("u pressed a 2 my homeboy");
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        static IEnumerable<Account> ReadAccounts()
        {
            String file = "../../data/account.json";

            using (StreamReader r = new StreamReader(file))
            { 
                string data = r.ReadToEnd();
                // Console.WriteLine(data);

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );

                //Console.WriteLine(json[0]);
                return json;
            }
        }

    }

    public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize<Account>(this);
        }
    }

}
/*
1. Create a menu driven console application with the menu choices.
2. The user should select what to do and the application should close when the user selects "Exit" from the menu.
3. The choice "View accounts" should load the accounts from the JSON file and print out a pretty formatted text table with a header and details of all accounts.
4. The choice "View account by number" should ask the user for an id and show the account that matches that id.
*/