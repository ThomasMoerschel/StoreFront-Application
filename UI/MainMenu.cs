using System;

namespace StoreAppUI
{
    public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("======================================");
            Console.WriteLine("[3] Make an Order");
            Console.WriteLine("[2] Go to StoreFront Management Menu");
            Console.WriteLine("[1] Go to Customer Management Menu");
            Console.WriteLine("======================================");
            Console.WriteLine("[0] Exit");
        }
        public MenuType UserInput ()
        {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        return MenuType.Exit;
                    case "1":
                        return MenuType.CustomerMenu;
                    case "2":
                        return MenuType.ManagementFindStoreFrontMenu;
                    case "3":
                        return MenuType.CustomerFindStoreFrontMenu;
                    default:
                        Console.WriteLine("========================");
                        Console.WriteLine("Input was not correct");
                        Console.WriteLine("Press ENTER to Continue");
                        Console.WriteLine("========================");
                        Console.ReadLine();
                        return MenuType.MainMenu;
                }
        }
    }
}