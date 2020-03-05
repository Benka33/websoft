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
            Console.Write("\r\nSelect an option: \n");
         
            switch (Console.ReadLine())
            {
                case "1":
                System.Console.WriteLine("+--------+--------+----------+---------+");
                    Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", "Number", "Owner", "Balance", "Label");
                    System.Console.WriteLine("+--------+--------+----------+---------+");
                    foreach (var account in accounts) {
                        Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", account.Number, account.Owner, account.Balance, account.Label);
                }
                System.Console.WriteLine("|--------------------------------------|");
                    return true;
                case "2":
                    Console.WriteLine("Enter ID to search for: ");
                    var id = Console.ReadLine();

                    int accountNumber;
                    bool parseInt = int.TryParse(id, out accountNumber);

                    if (parseInt) {

                    bool exists = false;

                    foreach (var account in accounts) {

                        if (account.Number == accountNumber) {
                            System.Console.WriteLine("+--------+--------+----------+---------+");
                            Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", "Number", "Owner", "Balance", "Label");
                            System.Console.WriteLine("+--------+--------+----------+---------+");
                            Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", account.Number, account.Owner, account.Balance, account.Label); 
                            System.Console.WriteLine("|--------------------------------------|");
                            Console.WriteLine("");
                            exists = true;
                         }

                    }

                    if (!exists) {
                    Console.WriteLine("Account does not exists");
                    Console.WriteLine("");
                    }

                    }

                    
                    return true;
                case "3":
                Console.Write("Goodbye");
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
                //Console.WriteLine(data);

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