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
            bool menu = true;
            while (menu)
            {
                menu = bankMenu();
            }
        }

        private static bool bankMenu()
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
                        Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", account.number, account.owner, account.balance, account.label);
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

                        if (account.number == accountNumber) {
                            System.Console.WriteLine("+--------+--------+----------+---------+");
                            Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", "Number", "Owner", "Balance", "Label");
                            System.Console.WriteLine("+--------+--------+----------+---------+");
                            Console.WriteLine("| {0,-6} | {1,-6} | {2,-8} | {3,-7} |", account.number, account.owner, account.balance, account.label); 
                            System.Console.WriteLine("+--------------------------------------+");
                            Console.WriteLine("");
                            exists = true;
                         }

                    }

                    if (!exists) {
                    Console.WriteLine("No such account exist");
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

            using (StreamReader reader = new StreamReader(file))
            { 
                string data = reader.ReadToEnd();

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return json;
            }
        }
    }

    public class Account
    {
        public int number { get; set; }
        public int balance { get; set; }
        public string label { get; set; }
        public int owner { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize<Account>(this);
        }
    }

}