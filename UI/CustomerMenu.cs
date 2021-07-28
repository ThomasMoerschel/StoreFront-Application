using System;
using System.Threading;

namespace StoreAppUI
{
    public class CustomerMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to the Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("===========================================");
            Console.WriteLine("[4] View a Customer's Order History");
            Console.WriteLine("[3] Add a Customer");
            Console.WriteLine("[2] Search for a Customer");
            Console.WriteLine("[1] Retrieve a List of Admitted Customers");
            Console.WriteLine("===========================================");
            Console.WriteLine("[0] Go Back");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.ShowCustomerMenu;
                case "2":
                    return MenuType.SearchCustomerMenu;
                case "3":
                    return MenuType.AddCustomerMenu;
                case "4":
                    return MenuType.SearchCustomerOrderHistory;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}