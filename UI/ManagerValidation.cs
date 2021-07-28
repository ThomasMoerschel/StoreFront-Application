using System;
namespace StoreAppUI
{
    public class ManagerValidation : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Administrative Login:");
            Console.WriteLine("Please Input Your Username: ");
            Console.WriteLine("Please Input Your Password: ");
        }
        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            return MenuType.AdministratorMenu;
        }
    }
}